// -----------------------------------------------------------------------
// <copyright file="CustomRole.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.CustomRoles.API.Features
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Dissonance.Integrations.MirrorIgnorance;

    using Exiled.API.Enums;
    using Exiled.API.Extensions;
    using Exiled.API.Features;
    using Exiled.API.Features.Items;
    using Exiled.API.Features.Spawn;
    using Exiled.CustomItems;
    using Exiled.CustomItems.API.Features;
    using Exiled.Events.EventArgs;
    using Exiled.Loader;

    using MEC;

    using NorthwoodLib.Pools;

    using UnityEngine;

    using YamlDotNet.Serialization;

    using Ragdoll = Ragdoll;

    /// <summary>
    /// The custom role base class.
    /// </summary>
    public abstract class CustomRole
    {
        /// <summary>
        /// Gets a list of all registered custom roles.
        /// </summary>
        public static HashSet<CustomRole> Registered { get; } = new HashSet<CustomRole>();

        /// <summary>
        /// Gets or sets the custom RoleID of the role.
        /// </summary>
        public abstract uint Id { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="RoleType"/> to spawn this role as.
        /// </summary>
        public abstract RoleType Role { get; set; }

        /// <summary>
        /// Gets or sets the max <see cref="Exiled.API.Features.Player.Health"/> for the role.
        /// </summary>
        public abstract int MaxHealth { get; set; }

        /// <summary>
        /// Gets or sets the name of this role.
        /// </summary>
        public abstract string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of this role.
        /// </summary>
        public abstract string Description { get; set; }

        /// <summary>
        /// Gets all of the players currently set to this role.
        /// </summary>
        [YamlIgnore]
        public HashSet<Player> TrackedPlayers { get; } = new HashSet<Player>();

        /// <summary>
        /// Gets or sets a list of the roles custom abilities.
        /// </summary>
        public virtual List<CustomAbility> CustomAbilities { get; set; } = new List<CustomAbility>();

        /// <summary>
        /// Gets or sets the starting inventory for the role.
        /// </summary>
        protected virtual List<string> Inventory { get; set; } = new List<string>();

        /// <summary>
        /// Gets or sets the possible spawn locations for this role.
        /// </summary>
        protected virtual SpawnProperties SpawnProperties { get; set; } = new SpawnProperties();

        /// <summary>
        /// Gets or sets a value indicating whether players keep their current inventory when gaining this role.
        /// </summary>
        protected virtual bool KeepInventoryOnSpawn { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether players die when this role is removed.
        /// </summary>
        protected virtual bool RemovalKillsPlayer { get; set; } = true;

        /// <summary>
        /// Gets or sets a value indicating whether players keep this role when they die.
        /// </summary>
        protected virtual bool KeepRoleOnDeath { get; set; }

        /// <summary>
        /// Gets a <see cref="CustomRole"/> by ID.
        /// </summary>
        /// <param name="id">The ID of the role to get.</param>
        /// <returns>The role, or null if it doesn't exist.</returns>
        public static CustomRole Get(int id) => Registered?.FirstOrDefault(r => r.Id == id);

        /// <summary>
        /// Gets a <see cref="CustomRole"/> by type.
        /// </summary>
        /// <param name="t">The <see cref="Type"/> to get.</param>
        /// <returns>The role, or null if it doesn't exist.</returns>
        public static CustomRole Get(Type t) => Registered.FirstOrDefault(r => r.GetType() == t);

        /// <summary>
        /// Gets a <see cref="CustomRole"/> by name.
        /// </summary>
        /// <param name="name">The name of the role to get.</param>
        /// <returns>The role, or null if it doesn't exist.</returns>
        public static CustomRole Get(string name) => Registered?.FirstOrDefault(r => r.Name == name);

        /// <summary>
        /// Tries to get a <see cref="CustomRole"/> by <inheritdoc cref="Id"/>.
        /// </summary>
        /// <param name="id">The ID of the role to get.</param>
        /// <param name="customRole">The custom role.</param>
        /// <returns>True if the role exists.</returns>
        public static bool TryGet(int id, out CustomRole customRole)
        {
            customRole = Get(id);

            return customRole != null;
        }

        /// <summary>
        /// Tries to get a <see cref="CustomRole"/> by name.
        /// </summary>
        /// <param name="name">The name of the role to get.</param>
        /// <param name="customRole">The custom role.</param>
        /// <returns>True if the role exists.</returns>
        /// <exception cref="ArgumentNullException">If the name is a null or empty string.</exception>
        public static bool TryGet(string name, out CustomRole customRole)
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentNullException(nameof(name));

            customRole = int.TryParse(name, out int id) ? Get(id) : Get(name);

            return customRole != null;
        }

        /// <summary>
        /// Tries to get a <see cref="IReadOnlyCollection{T}"/> of the specified <see cref="Player"/>'s <see cref="CustomRole"/>s.
        /// </summary>
        /// <param name="player">The player to check.</param>
        /// <param name="customRoles">The custom roles the player has.</param>
        /// <returns>True if the player has custom roles.</returns>
        /// <exception cref="ArgumentNullException">If the player is null.</exception>
        public static bool TryGet(Player player, out IReadOnlyCollection<CustomRole> customRoles)
        {
            if (player == null)
                throw new ArgumentNullException(nameof(player));

            List<CustomRole> tempList = ListPool<CustomRole>.Shared.Rent();
            tempList.AddRange(Registered?.Where(customRole => customRole.Check(player)) ?? Array.Empty<CustomRole>());

            customRoles = tempList.AsReadOnly();
            ListPool<CustomRole>.Shared.Return(tempList);

            return customRoles?.Count > 0;
        }

        /// <summary>
        /// Checks if the given player has this role.
        /// </summary>
        /// <param name="player">The <see cref="Player"/> to check.</param>
        /// <returns>True if the player has this role.</returns>
        public virtual bool Check(Player player) => TrackedPlayers.Contains(player);

        /// <summary>
        /// Tries to register this role.
        /// </summary>
        /// <returns>True if the role registered properly.</returns>
        public bool TryRegister()
        {
            if (!Registered.Contains(this))
            {
                if (Registered.Any(r => r.Id == Id))
                {
                    Log.Warn($"{Name} has tried to register with the same Role ID as another role: {Id}. It will not be registered!");

                    return false;
                }

                Registered.Add(this);
                Init();

                Log.Debug($"{Name} ({Id}) has been successfully registered.", CustomRoles.Instance.Config.Debug);

                return true;
            }

            Log.Warn($"Couldn't register {Name} ({Id}) [{Role}] as it already exists.");

            return false;
        }

        /// <summary>
        /// Tries to unregister this role.
        /// </summary>
        /// <returns>True if the role is unregistered properly.</returns>
        public bool TryUnregister()
        {
            Destroy();

            if (!Registered.Remove(this))
            {
                Log.Warn($"Cannot unregister {Name} ({Id}) [{Role}], it hasn't been registered yet.");

                return false;
            }

            return true;
        }

        /// <summary>
        /// Initializes this role manager.
        /// </summary>
        public virtual void Init() => SubscribeEvents();

        /// <summary>
        /// Destroys this role manager.
        /// </summary>
        public virtual void Destroy() => UnSubscribeEvents();

        /// <summary>
        /// Handles setup of the role, including spawn location, inventory and registering event handlers.
        /// </summary>
        /// <param name="player">The <see cref="Player"/> to add the role to.</param>
        public virtual void AddRole(Player player)
        {
            Log.Debug($"{Name}: Adding role to {player.Nickname}.", CustomRoles.Instance.Config.Debug);
            if (Role != RoleType.None)
            {
                player.SetRole(Role, SpawnReason.ForceClass, true);
            }

            Timing.CallDelayed(1.5f, () =>
            {
                Vector3 pos = GetSpawnPosition();

                // If the spawn pos isn't 0,0,0, We add vector3.up * 1.5 here to ensure they do not spawn inside the ground and get stuck.
                if (pos != Vector3.zero)
                    player.Position = pos + (Vector3.up * 1.5f);

                if (!KeepInventoryOnSpawn)
                {
                    Log.Debug($"{Name}: Clearing {player.Nickname}'s inventory.", CustomRoles.Instance.Config.Debug);
                    player.ClearInventory();
                }

                foreach (string itemName in Inventory)
                {
                    Log.Debug($"{Name}: Adding {itemName} to inventory.", CustomRoles.Instance.Config.Debug);
                    TryAddItem(player, itemName);
                }

                Log.Debug($"{Name}: Setting health values.", CustomRoles.Instance.Config.Debug);
                player.Health = MaxHealth;
                player.MaxHealth = MaxHealth;
            });

            Log.Debug($"{Name}: Setting player info", CustomRoles.Instance.Config.Debug);
            player.CustomInfo = $"{Name} (Custom Role)";
            foreach (CustomAbility ability in CustomAbilities)
                ability.AddAbility(player);
            ShowMessage(player);
            RoleAdded(player);
            TrackedPlayers.Add(player);
        }

        /// <summary>
        /// Removes the role from a specific player.
        /// </summary>
        /// <param name="player">The <see cref="Player"/> to remove the role from.</param>
        public virtual void RemoveRole(Player player)
        {
            TrackedPlayers.Remove(player);
            if (RemovalKillsPlayer)
                player.Role = RoleType.Spectator;
            foreach (CustomAbility ability in CustomAbilities)
            {
                ability.RemoveAbility(player);
            }

            RoleRemoved(player);
        }

        /// <summary>
        /// Tries to add an item to the player's inventory by name.
        /// </summary>
        /// <param name="player">The <see cref="Player"/> to try giving the item to.</param>
        /// <param name="itemName">The name of the item to try adding.</param>
        /// <returns>Whether or not the item was able to be added.</returns>
        protected bool TryAddItem(Player player, string itemName)
        {
            if (CustomItem.TryGet(itemName, out CustomItem customItem))
            {
                customItem.Give(player);

                return true;
            }

            if (Enum.TryParse(itemName, out ItemType type))
            {
                if (type.IsAmmo())
                    player.Ammo[type] = 100;
                else
                    player.AddItem(type);

                return true;
            }

            Log.Warn($"{Name}: {nameof(TryAddItem)}: {itemName} is not a valid ItemType or Custom Item name.");

            return false;
        }

        /// <summary>
        /// Gets a random <see cref="Vector3"/> from <see cref="SpawnProperties"/>.
        /// </summary>
        /// <returns>The chosen spawn location.</returns>
        protected Vector3 GetSpawnPosition()
        {
            if (SpawnProperties == null || SpawnProperties.Count() == 0)
                return Vector3.zero;

            if (SpawnProperties.StaticSpawnPoints.Count > 0)
            {
                foreach ((float chance, Vector3 pos) in SpawnProperties.StaticSpawnPoints)
                {
                    int r = Loader.Random.Next(100);
                    if (r <= chance)
                        return pos;
                }
            }

            if (SpawnProperties.DynamicSpawnPoints.Count > 0)
            {
                foreach ((float chance, Vector3 pos) in SpawnProperties.DynamicSpawnPoints)
                {
                    int r = Loader.Random.Next(100);
                    if (r <= chance)
                        return pos;
                }
            }

            if (SpawnProperties.RoleSpawnPoints.Count > 0)
            {
                foreach ((float chance, Vector3 pos) in SpawnProperties.RoleSpawnPoints)
                {
                    int r = Loader.Random.Next(100);
                    if (r <= chance)
                        return pos;
                }
            }

            return Vector3.zero;
        }

        /// <summary>
        /// Called when the role is initialized to setup internal events.
        /// </summary>
        protected virtual void SubscribeEvents()
        {
            Log.Debug($"{Name}: Loading events.", CustomRoles.Instance.Config.Debug);
            Exiled.Events.Handlers.Player.ChangingRole += OnInternalChangingRole;
            Exiled.Events.Handlers.Player.Dying += OnInternalDying;
        }

        /// <summary>
        /// Called when the role is destroyed to unsubscribe internal event handlers.
        /// </summary>
        protected virtual void UnSubscribeEvents()
        {
            foreach (Player player in TrackedPlayers)
                RemoveRole(player);

            Log.Debug($"{Name}: Unloading events.", CustomRoles.Instance.Config.Debug);
            Exiled.Events.Handlers.Player.ChangingRole -= OnInternalChangingRole;
            Exiled.Events.Handlers.Player.Dying -= OnInternalDying;
        }

        /// <summary>
        /// Shows the spawn message to the player.
        /// </summary>
        /// <param name="player">The <see cref="Player"/> to show the message to.</param>
        protected virtual void ShowMessage(Player player) => player.ShowHint(string.Format(CustomRoles.Instance.Config.GotRoleHint.Content, Name, Description), CustomRoles.Instance.Config.GotRoleHint.Duration);

        /// <summary>
        /// Called after the role has been added to the player.
        /// </summary>
        /// <param name="player">The <see cref="Player"/> the role was added to.</param>
        protected virtual void RoleAdded(Player player)
        {
        }

        /// <summary>
        /// Called 1 frame before the role is removed from the player.
        /// </summary>
        /// <param name="player">The <see cref="Player"/> the role was removed from.</param>
        protected virtual void RoleRemoved(Player player)
        {
        }

        private void OnInternalChangingRole(ChangingRoleEventArgs ev)
        {
            if (Check(ev.Player) && ((ev.NewRole == RoleType.Spectator && !KeepRoleOnDeath) || (ev.NewRole != RoleType.Spectator && ev.NewRole != Role)))
                RemoveRole(ev.Player);
        }

        private void OnInternalDying(DyingEventArgs ev)
        {
            if (Check(ev.Target))
            {
                CustomRoles.Instance.StopRagdollPlayers.Add(ev.Target);
                Role role = CharacterClassManager._staticClasses.SafeGet(Role);
                Ragdoll.Info info = new Ragdoll.Info
                {
                    ClassColor = role.classColor,
                    DeathCause = ev.HitInformation,
                    FullName = Name,
                    Nick = ev.Target.Nickname,
                    ownerHLAPI_id = ev.Target.GameObject.GetComponent<MirrorIgnorancePlayer>().PlayerId,
                    PlayerId = ev.Target.Id,
                };
                Exiled.API.Features.Ragdoll.Spawn(role, info, ev.Target.Position, Quaternion.Euler(ev.Target.Rotation));
            }
        }
    }
}
