// -----------------------------------------------------------------------
// <copyright file="Player.cs" company="Exiled Team">
// Copyright (c) Exiled Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.Handlers
{
    using Exiled.Events.EventArgs;
    using Exiled.Events.Extensions;

    using static Exiled.Events.Events;

    /// <summary>
    /// Player related events.
    /// </summary>
    public static class Player
    {
        /// <summary>
        /// Invoked before authenticating a player.
        /// </summary>
        public static event CustomEventHandler<PreAuthenticatingEventArgs> PreAuthenticating;

        /// <summary>
        /// Invoked before kicking a player from the server.
        /// </summary>
        public static event CustomEventHandler<KickingEventArgs> Kicking;

        /// <summary>
        /// Invoked after a player has been kicked from the server.
        /// </summary>
        public static event CustomEventHandler<KickedEventArgs> Kicked;

        /// <summary>
        /// Invoked before banning a player from the server.
        /// </summary>
        public static event CustomEventHandler<BanningEventArgs> Banning;

        /// <summary>
        /// Invoked after a player has been banned from the server.
        /// </summary>
        public static event CustomEventHandler<BannedEventArgs> Banned;

        /// <summary>
        /// Invoked after a player uses an item.
        /// </summary>
        /// <remarks>
        /// Invoked after <see cref="ItemUsed"/>, if a player's class has
        /// changed during their health increase, won't fire.
        /// </remarks>
        public static event CustomEventHandler<UsedItemEventArgs> ItemUsed;

        /// <summary>
        /// Invoked after a player has stopped the use of a medical item.
        /// </summary>
        public static event CustomEventHandler<CancellingItemUseEventArgs> CancellingItemUse;

        /// <summary>
        /// Invoked after a player interacted with something.
        /// </summary>
        public static event CustomEventHandler<InteractedEventArgs> Interacted;

        /// <summary>
        /// Invoked before spawning a player's ragdoll.
        /// </summary>
        public static event CustomEventHandler<SpawningRagdollEventArgs> SpawningRagdoll;

        /// <summary>
        /// Invoked before activating the warhead panel.
        /// </summary>
        public static event CustomEventHandler<ActivatingWarheadPanelEventArgs> ActivatingWarheadPanel;

        /// <summary>
        /// Invoked before activating a workstation.
        /// </summary>
        public static event CustomEventHandler<ActivatingWorkstationEventArgs> ActivatingWorkstation;

        /// <summary>
        /// Invoked before deactivating a workstation.
        /// </summary>
        public static event CustomEventHandler<DeactivatingWorkstationEventArgs> DeactivatingWorkstation;

        /// <summary>
        /// Invoked before using an item.
        /// </summary>
        public static event CustomEventHandler<UsingItemEventArgs> UsingItem;

        /// <summary>
        /// Invoked after a player has joined the server.
        /// </summary>
        public static event CustomEventHandler<JoinedEventArgs> Joined;

        /// <summary>
        /// Ivoked after a player has been verified.
        /// </summary>
        public static event CustomEventHandler<VerifiedEventArgs> Verified;

        /// <summary>
        /// Invoked after a player has left the server.
        /// </summary>
        public static event CustomEventHandler<LeftEventArgs> Left;

        /// <summary>
        /// Invoked before destroying a player.
        /// </summary>
        public static event CustomEventHandler<DestroyingEventArgs> Destroying;

        /// <summary>
        /// Invoked before hurting a player.
        /// </summary>
        public static event CustomEventHandler<HurtingEventArgs> Hurting;

        /// <summary>
        /// Invoked before a player dies.
        /// </summary>
        public static event CustomEventHandler<DyingEventArgs> Dying;

        /// <summary>
        /// Invoked after a player died.
        /// </summary>
        public static event CustomEventHandler<DiedEventArgs> Died;

        /// <summary>
        /// Invoked before changing a player's role.
        /// </summary>
        /// <remarks>If you set IsAllowed to false when Escape is true, tickets will still be given to the escapee's team even though they will 'fail' to escape. Use <see cref="Escaping"/> to block escapes instead.</remarks>
        public static event CustomEventHandler<ChangingRoleEventArgs> ChangingRole;

        /// <summary>
        /// Invoked before throwing an item.
        /// </summary>
        public static event CustomEventHandler<ThrowingItemEventArgs> ThrowingItem;

        /// <summary>
        /// Invoked before dropping an item.
        /// </summary>
        public static event CustomEventHandler<DroppingItemEventArgs> DroppingItem;

        /// <summary>
        /// Invoked before dropping a null item.
        /// </summary>
        public static event CustomEventHandler<DroppingNullEventArgs> DroppingNull;

        /// <summary>
        /// Invoked before picking up ammo.
        /// </summary>
        public static event CustomEventHandler<PickingUpAmmoEventArgs> PickingUpAmmo;

        /// <summary>
        /// Invoked before picking up armor.
        /// </summary>
        public static event CustomEventHandler<PickingUpArmorEventArgs> PickingUpArmor;

        /// <summary>
        /// Invoked before picking up an item.
        /// </summary>
        public static event CustomEventHandler<PickingUpItemEventArgs> PickingUpItem;

        /// <summary>
        /// Invoked before handcuffing a player.
        /// </summary>
        public static event CustomEventHandler<HandcuffingEventArgs> Handcuffing;

        /// <summary>
        /// Invoked before freeing a handcuffed player.
        /// </summary>
        public static event CustomEventHandler<RemovingHandcuffsEventArgs> RemovingHandcuffs;

        /// <summary>
        /// Invoked before a player escapes.
        /// </summary>
        public static event CustomEventHandler<EscapingEventArgs> Escaping;

        /// <summary>
        /// Invoked before a player begins speaking to the intercom.
        /// </summary>
        public static event CustomEventHandler<IntercomSpeakingEventArgs> IntercomSpeaking;

        /// <summary>
        /// Invoked after a player gets shot.
        /// </summary>
        public static event CustomEventHandler<ShotEventArgs> Shot;

        /// <summary>
        /// Invoked before a player shoots a weapon.
        /// </summary>
        public static event CustomEventHandler<ShootingEventArgs> Shooting;

        /// <summary>
        /// Invoked before a player enters the pocket dimension.
        /// </summary>
        public static event CustomEventHandler<EnteringPocketDimensionEventArgs> EnteringPocketDimension;

        /// <summary>
        /// Invoked before a player escapes the pocket dimension.
        /// </summary>
        public static event CustomEventHandler<EscapingPocketDimensionEventArgs> EscapingPocketDimension;

        /// <summary>
        /// Invoked before a player fails to escape the pocket dimension.
        /// </summary>
        public static event CustomEventHandler<FailingEscapePocketDimensionEventArgs> FailingEscapePocketDimension;

        /// <summary>
        /// Invoked before a player reloads a weapon.
        /// </summary>
        public static event CustomEventHandler<ReloadingWeaponEventArgs> ReloadingWeapon;

        /// <summary>
        /// Invoked before spawning a player.
        /// </summary>
        public static event CustomEventHandler<SpawningEventArgs> Spawning;

        /// <summary>
        /// Invoked before a player enters the femur breaker.
        /// </summary>
        public static event CustomEventHandler<EnteringFemurBreakerEventArgs> EnteringFemurBreaker;

        /// <summary>
        /// Invoked before syncing player's data.
        /// </summary>
        public static event CustomEventHandler<SyncingDataEventArgs> SyncingData;

        /// <summary>
        /// Invoked before a player's held item changes.
        /// </summary>
        public static event CustomEventHandler<ChangingItemEventArgs> ChangingItem;

        /// <summary>
        /// Invoked before changing a player's group.
        /// </summary>
        public static event CustomEventHandler<ChangingGroupEventArgs> ChangingGroup;

        /// <summary>
        /// Invoked before a player interacts with a door.
        /// </summary>
        public static event CustomEventHandler<InteractingDoorEventArgs> InteractingDoor;

        /// <summary>
        /// Invoked before a player interacts with an elevator.
        /// </summary>
        public static event CustomEventHandler<InteractingElevatorEventArgs> InteractingElevator;

        /// <summary>
        /// Invoked before a player interacts with a locker.
        /// </summary>
        public static event CustomEventHandler<InteractingLockerEventArgs> InteractingLocker;

        /// <summary>
        /// Invoked before a player triggers a tesla gate.
        /// </summary>
        public static event CustomEventHandler<TriggeringTeslaEventArgs> TriggeringTesla;

        /// <summary>
        /// Invoked before a player unlocks a generator.
        /// </summary>
        public static event CustomEventHandler<UnlockingGeneratorEventArgs> UnlockingGenerator;

        /// <summary>
        /// Invoked before a player opens a generator.
        /// </summary>
        public static event CustomEventHandler<OpeningGeneratorEventArgs> OpeningGenerator;

        /// <summary>
        /// Invoked before a player closes a generator.
        /// </summary>
        public static event CustomEventHandler<ClosingGeneratorEventArgs> ClosingGenerator;

        /// <summary>
        /// Invoked before a player inserts a workstation tablet into a generator.
        /// </summary>
        public static event CustomEventHandler<ActivatingGeneratorEventArgs> ActivatingGenerator;

        /// <summary>
        /// Invoked before a player ejects the workstation tablet out of a generator.
        /// </summary>
        public static event CustomEventHandler<StoppingGeneratorEventArgs> StoppingGenerator;

        /// <summary>
        /// Invoked before a player receives a status effect.
        /// </summary>
        public static event CustomEventHandler<ReceivingEffectEventArgs> ReceivingEffect;

        /// <summary>
        /// Invoked before an user's mute status is changed.
        /// </summary>
        public static event CustomEventHandler<ChangingMuteStatusEventArgs> ChangingMuteStatus;

        /// <summary>
        /// Invoked before an user's intercom mute status is changed.
        /// </summary>
        public static event CustomEventHandler<ChangingIntercomMuteStatusEventArgs> ChangingIntercomMuteStatus;

        /// <summary>
        /// Invoked before a user's radio battery charge is changed.
        /// </summary>
        public static event CustomEventHandler<UsingRadioBatteryEventArgs> UsingRadioBattery;

        /// <summary>
        /// Invoked before a user's radio preset is changed.
        /// </summary>
        public static event CustomEventHandler<ChangingRadioPresetEventArgs> ChangingRadioPreset;

        /// <summary>
        /// Invoked before a player's MicroHID state is changed.
        /// </summary>
        public static event CustomEventHandler<ChangingMicroHIDStateEventArgs> ChangingMicroHIDState;

        /// <summary>
        /// Invoked before a player's MicroHID energy is changed.
        /// </summary>
        public static event CustomEventHandler<UsingMicroHIDEnergyEventArgs> UsingMicroHIDEnergy;

        /// <summary>
        /// Called before processing a hotkey.
        /// </summary>
        public static event CustomEventHandler<ProcessingHotkeyEventArgs> ProcessingHotkey;

        /// <summary>
        /// Invoked before dropping ammo.
        /// </summary>
        public static event CustomEventHandler<DroppingAmmoEventArgs> DroppingAmmo;

        /// <summary>
        /// Called before a player walks on a sinkhole.
        /// </summary>
        public static event CustomEventHandler<WalkingOnSinkholeEventArgs> WalkingOnSinkhole;

        /// <summary>
        /// Invoked before a player interacts with a shooting target.
        /// </summary>
        public static event CustomEventHandler<InteractingShootingTargetEventArgs> InteractingShootingTarget;

        /// <summary>
        /// Invoked before a player damages a shooting target.
        /// </summary>
        public static event CustomEventHandler<DamagingShootingTargetEventArgs> DamagingShootingTarget;

        /// <summary>
        /// Invoked before a player flips a coin.
        /// </summary>
        public static event CustomEventHandler<FlippingCoinEventArgs> FlippingCoin;

        /// <summary>
        /// Invoked before a player unloads a weapon.
        /// </summary>
        public static event CustomEventHandler<UnloadingWeaponEventArgs> UnloadingWeapon;

        /// <summary>
        /// Invoked before a player triggers an aim action.
        /// </summary>
        public static event CustomEventHandler<AimingDownSightEventArgs> AimingDownSight;

        /// <summary>
        /// Invoked before a player toggles the weapon's flashlight.
        /// </summary>
        public static event CustomEventHandler<TogglingWeaponFlashlightEventArgs> TogglingWeaponFlashlight;

        /// <summary>
        /// Invoked before a player dryfires a weapon.
        /// </summary>
        public static event CustomEventHandler<DryfiringWeaponEventArgs> DryfiringWeapon;

        /// <summary>
        /// Called before a player walks on a tantrum.
        /// </summary>
        public static event CustomEventHandler<WalkingOnTantrumEventArgs> WalkingOnTantrum;

        /// <summary>
        /// Invoked after a player presses the voicechat key.
        /// </summary>
        public static event CustomEventHandler<VoiceChattingEventArgs> VoiceChatting;

        /// <summary>
        /// Invoked before a player makes noise.
        /// </summary>
        public static event CustomEventHandler<MakingNoiseEventArgs> MakingNoise;

        /// <summary>
        /// Invoked before a player jumps.
        /// </summary>
        public static event CustomEventHandler<JumpingEventArgs> Jumping;

        /// <summary>
        /// Invoked after a player presses the transmission key.
        /// </summary>
        public static event CustomEventHandler<TransmittingEventArgs> Transmitting;

        /// <summary>
        /// Invoked before a player changes move state.
        /// </summary>
        public static event CustomEventHandler<ChangingMoveStateEventArgs> ChangingMoveState;

        /// <summary>
        /// Invoked before a player toggles the NoClip mode.
        /// </summary>
        public static event CustomEventHandler<TogglingNoClipEventArgs> TogglingNoClip;
        /// <summary>
        /// Invoked after a player changed spectated player.
        /// </summary>
        public static event CustomEventHandler<ChangingSpectatedPlayerEventArgs> ChangingSpectatedPlayer;

        /// <summary>
        /// Called before pre-authenticating a player.
        /// </summary>
        /// <param name="ev">The <see cref="PreAuthenticatingEventArgs"/> instance.</param>
        public static void OnPreAuthenticating(PreAuthenticatingEventArgs ev) => PreAuthenticating.InvokeSafely(ev);

        /// <summary>
        /// Called before kicking a player from the server.
        /// </summary>
        /// <param name="ev">The <see cref="KickingEventArgs"/> instance.</param>
        public static void OnKicking(KickingEventArgs ev) => Kicking.InvokeSafely(ev);

        /// <summary>
        /// Called after a player has been kicked from the server.
        /// </summary>
        /// <param name="ev">The <see cref="KickedEventArgs"/> instance.</param>
        public static void OnKicked(KickedEventArgs ev) => Kicked.InvokeSafely(ev);

        /// <summary>
        /// Called before banning a player from the server.
        /// </summary>
        /// <param name="ev">The <see cref="BanningEventArgs"/> instance.</param>
        public static void OnBanning(BanningEventArgs ev) => Banning.InvokeSafely(ev);

        /// <summary>
        /// Called after a player has been banned from the server.
        /// </summary>
        /// <param name="ev">The <see cref="BannedEventArgs"/> instance.</param>
        public static void OnBanned(BannedEventArgs ev) => Banned.InvokeSafely(ev);

        /// <summary>
        /// Called after a player used a medical item.
        /// </summary>
        /// <param name="ev">The <see cref="UsedItemEventArgs"/> instance.</param>
        public static void OnItemUsed(UsedItemEventArgs ev) => ItemUsed.InvokeSafely(ev);

        /// <summary>
        /// Called after a player has stopped the use of a medical item.
        /// </summary>
        /// <param name="ev">The <see cref="CancellingItemUseEventArgs"/> instance.</param>
        public static void OnCancellingItemUse(CancellingItemUseEventArgs ev) => CancellingItemUse.InvokeSafely(ev);

        /// <summary>
        /// Called after a player interacted with something.
        /// </summary>
        /// <param name="ev">The <see cref="InteractedEventArgs"/> instance.</param>
        public static void OnInteracted(InteractedEventArgs ev) => Interacted.InvokeSafely(ev);

        /// <summary>
        /// Called before spawning a player's ragdoll.
        /// </summary>
        /// <param name="ev">The <see cref="SpawningRagdollEventArgs"/> instance.</param>
        public static void OnSpawningRagdoll(SpawningRagdollEventArgs ev) => SpawningRagdoll.InvokeSafely(ev);

        /// <summary>
        /// Called before activating the warhead panel.
        /// </summary>
        /// <param name="ev">The <see cref="ActivatingWarheadPanelEventArgs"/> instance.</param>
        public static void OnActivatingWarheadPanel(ActivatingWarheadPanelEventArgs ev) => ActivatingWarheadPanel.InvokeSafely(ev);

        /// <summary>
        /// Called before activating a workstation.
        /// </summary>
        /// <param name="ev">The <see cref="ActivatingWorkstation"/> instance.</param>
        public static void OnActivatingWorkstation(ActivatingWorkstationEventArgs ev) => ActivatingWorkstation.InvokeSafely(ev);

        /// <summary>
        /// Called before deactivating a workstation.
        /// </summary>
        /// <param name="ev">The <see cref="DeactivatingWorkstationEventArgs"/> instance.</param>
        public static void OnDeactivatingWorkstation(DeactivatingWorkstationEventArgs ev) => DeactivatingWorkstation.InvokeSafely(ev);

        /// <summary>
        /// Called before using a medical item.
        /// </summary>
        /// <param name="ev">The <see cref="UsingItemEventArgs"/> instance.</param>
        public static void OnUsingItem(UsingItemEventArgs ev) => UsingItem.InvokeSafely(ev);

        /// <summary>
        /// Called after a player has joined the server.
        /// </summary>
        /// <param name="ev">The <see cref="JoinedEventArgs"/> instance.</param>
        public static void OnJoined(JoinedEventArgs ev) => Joined.InvokeSafely(ev);

        /// <summary>
        /// Called after a player has been verified.
        /// </summary>
        /// <param name="ev">The <see cref="VerifiedEventArgs"/> instance.</param>
        public static void OnVerified(VerifiedEventArgs ev) => Verified.InvokeSafely(ev);

        /// <summary>
        /// Called after a player has left the server.
        /// </summary>
        /// <param name="ev">The <see cref="LeftEventArgs"/> instance.</param>
        public static void OnLeft(LeftEventArgs ev) => Left.InvokeSafely(ev);

        /// <summary>
        /// Called before destroying a player.
        /// </summary>
        /// <param name="ev">The <see cref="DestroyingEventArgs"/> instance.</param>
        public static void OnDestroying(DestroyingEventArgs ev) => Destroying.InvokeSafely(ev);

        /// <summary>
        /// Called before hurting a player.
        /// </summary>
        /// <param name="ev">The <see cref="HurtingEventArgs"/> instance.</param>
        public static void OnHurting(HurtingEventArgs ev) => Hurting.InvokeSafely(ev);

        /// <summary>
        /// Called before a player dies.
        /// </summary>
        /// <param name="ev"><see cref="DyingEventArgs"/> instance.</param>
        public static void OnDying(DyingEventArgs ev) => Dying.InvokeSafely(ev);

        /// <summary>
        /// Called after a player died.
        /// </summary>
        /// <param name="ev">The <see cref="DiedEventArgs"/> instance.</param>
        public static void OnDied(DiedEventArgs ev) => Died.InvokeSafely(ev);

        /// <summary>
        /// Called before changing a player's role.
        /// </summary>
        /// <param name="ev">The <see cref="ChangingRoleEventArgs"/> instance.</param>
        /// <remarks>If you set IsAllowed to false when Escape is true, tickets will still be given to the escapee's team even though they will 'fail' to escape. Use <see cref="Escaping"/> to block escapes instead.</remarks>
        public static void OnChangingRole(ChangingRoleEventArgs ev) => ChangingRole.InvokeSafely(ev);

        /// <summary>
        /// Called before throwing a grenade.
        /// </summary>
        /// <param name="ev">The <see cref="ThrowingItemEventArgs"/> instance.</param>
        public static void OnThrowingItem(ThrowingItemEventArgs ev) => ThrowingItem.InvokeSafely(ev);

        /// <summary>
        /// Called before dropping an item.
        /// </summary>
        /// <param name="ev">The <see cref="DroppingItemEventArgs"/> instance.</param>
        public static void OnDroppingItem(DroppingItemEventArgs ev) => DroppingItem.InvokeSafely(ev);

        /// <summary>
        /// Called before dropping a null item.
        /// </summary>
        /// <param name="ev">The <see cref="DroppingNullEventArgs"/> instance.</param>
        public static void OnDroppingNull(DroppingNullEventArgs ev) => DroppingNull.InvokeSafely(ev);

        /// <summary>
        /// Called before a player picks up ammo.
        /// </summary>
        /// <param name="ev">The <see cref="PickingUpAmmoEventArgs"/> instance.</param>
        public static void OnPickingUpAmmo(PickingUpAmmoEventArgs ev) => PickingUpAmmo.InvokeSafely(ev);

        /// <summary>
        /// Called before a player picks up armor.
        /// </summary>
        /// <param name="ev">The <see cref="PickingUpArmorEventArgs"/> instance.</param>
        public static void OnPickingUpArmor(PickingUpArmorEventArgs ev) => PickingUpArmor.InvokeSafely(ev);

        /// <summary>
        /// Called before a user picks up an item.
        /// </summary>
        /// <param name="ev">The <see cref="PickingUpItemEventArgs"/> instance.</param>
        public static void OnPickingUpItem(PickingUpItemEventArgs ev) => PickingUpItem.InvokeSafely(ev);

        /// <summary>
        /// Called before handcuffing a player.
        /// </summary>
        /// <param name="ev">The <see cref="HandcuffingEventArgs"/> instance.</param>
        public static void OnHandcuffing(HandcuffingEventArgs ev) => Handcuffing.InvokeSafely(ev);

        /// <summary>
        /// Called before freeing a handcuffed player.
        /// </summary>
        /// <param name="ev">The <see cref="RemovingHandcuffsEventArgs"/> instance.</param>
        public static void OnRemovingHandcuffs(RemovingHandcuffsEventArgs ev) => RemovingHandcuffs.InvokeSafely(ev);

        /// <summary>
        /// Called before a player escapes.
        /// </summary>
        /// <param name="ev">The <see cref="EscapingEventArgs"/> instance.</param>
        public static void OnEscaping(EscapingEventArgs ev) => Escaping.InvokeSafely(ev);

        /// <summary>
        /// Called before a player begins speaking to the intercom.
        /// </summary>
        /// <param name="ev">The <see cref="IntercomSpeakingEventArgs"/> instance.</param>
        public static void OnIntercomSpeaking(IntercomSpeakingEventArgs ev) => IntercomSpeaking.InvokeSafely(ev);

        /// <summary>
        /// Called after a player shoots a weapon.
        /// </summary>
        /// <param name="ev">The <see cref="ShotEventArgs"/> instance.</param>
        public static void OnShot(ShotEventArgs ev) => Shot.InvokeSafely(ev);

        /// <summary>
        /// Called before a player shoots a weapon.
        /// </summary>
        /// <param name="ev">The <see cref="ShootingEventArgs"/> instance.</param>
        public static void OnShooting(ShootingEventArgs ev) => Shooting.InvokeSafely(ev);

        /// <summary>
        /// Called before a player enters the pocket dimension.
        /// </summary>
        /// <param name="ev">The <see cref="EnteringPocketDimensionEventArgs"/> instance.</param>
        public static void OnEnteringPocketDimension(EnteringPocketDimensionEventArgs ev) => EnteringPocketDimension.InvokeSafely(ev);

        /// <summary>
        /// Called before a player escapes the pocket dimension.
        /// </summary>
        /// <param name="ev">The <see cref="EscapingPocketDimensionEventArgs"/> instance.</param>
        public static void OnEscapingPocketDimension(EscapingPocketDimensionEventArgs ev) => EscapingPocketDimension.InvokeSafely(ev);

        /// <summary>
        /// Called before a player fails to escape the pocket dimension.
        /// </summary>
        /// <param name="ev">The <see cref="FailingEscapePocketDimensionEventArgs"/> instance.</param>
        public static void OnFailingEscapePocketDimension(FailingEscapePocketDimensionEventArgs ev) => FailingEscapePocketDimension.InvokeSafely(ev);

        /// <summary>
        /// Called before a player reloads a weapon.
        /// </summary>
        /// <param name="ev">The <see cref="ReloadingWeaponEventArgs"/> instance.</param>
        public static void OnReloadingWeapon(ReloadingWeaponEventArgs ev) => ReloadingWeapon.InvokeSafely(ev);

        /// <summary>
        /// Called before spawning a player.
        /// </summary>
        /// <param name="ev">The <see cref="SpawningEventArgs"/> instance.</param>
        public static void OnSpawning(SpawningEventArgs ev) => Spawning.InvokeSafely(ev);

        /// <summary>
        /// Called before a player enters the femur breaker.
        /// </summary>
        /// <param name="ev">The <see cref="EnteringFemurBreakerEventArgs"/> instance.</param>
        public static void OnEnteringFemurBreaker(EnteringFemurBreakerEventArgs ev) => EnteringFemurBreaker.InvokeSafely(ev);

        /// <summary>
        /// Called before syncing player's data.
        /// </summary>
        /// <param name="ev">The <see cref="SyncingDataEventArgs"/> instance.</param>
        public static void OnSyncingData(SyncingDataEventArgs ev) => SyncingData.InvokeSafely(ev);

        /// <summary>
        /// Called before a player's held item changes.
        /// </summary>
        /// <param name="ev">The <see cref="ChangingItemEventArgs"/> instance.</param>
        public static void OnChangingItem(ChangingItemEventArgs ev) => ChangingItem.InvokeSafely(ev);

        /// <summary>
        /// Called before changing a player's group.
        /// </summary>
        /// <param name="ev">The <see cref="ChangingGroupEventArgs"/> instance.</param>
        public static void OnChangingGroup(ChangingGroupEventArgs ev) => ChangingGroup.InvokeSafely(ev);

        /// <summary>
        /// Called before a player interacts with a door.
        /// </summary>
        /// <param name="ev">The <see cref="PlacingBulletHole"/> instance.</param>
        public static void OnInteractingDoor(InteractingDoorEventArgs ev) => InteractingDoor.InvokeSafely(ev);

        /// <summary>
        /// Called before a player interacts with an elevator.
        /// </summary>
        /// <param name="ev">The <see cref="PlacingBulletHole"/> instance.</param>
        public static void OnInteractingElevator(InteractingElevatorEventArgs ev) => InteractingElevator.InvokeSafely(ev);

        /// <summary>
        /// Called before a player interacts with a locker.
        /// </summary>
        /// <param name="ev">The <see cref="PlacingBulletHole"/> instance.</param>
        public static void OnInteractingLocker(InteractingLockerEventArgs ev) => InteractingLocker.InvokeSafely(ev);

        /// <summary>
        /// Called before a player triggers a tesla.
        /// </summary>
        /// <param name="ev">The <see cref="TriggeringTeslaEventArgs"/> instance.</param>
        public static void OnTriggeringTesla(TriggeringTeslaEventArgs ev) => TriggeringTesla.InvokeSafely(ev);

        /// <summary>
        /// Called before a player unlocks a generator.
        /// </summary>
        /// <param name="ev">The <see cref="UnlockingGeneratorEventArgs"/> instance.</param>
        public static void OnUnlockingGenerator(UnlockingGeneratorEventArgs ev) => UnlockingGenerator.InvokeSafely(ev);

        /// <summary>
        /// Called before a player opens a generator.
        /// </summary>
        /// <param name="ev">The <see cref="OpeningGeneratorEventArgs"/> instance.</param>
        public static void OnOpeningGenerator(OpeningGeneratorEventArgs ev) => OpeningGenerator.InvokeSafely(ev);

        /// <summary>
        /// Called before a player closes a generator.
        /// </summary>
        /// <param name="ev">The <see cref="ClosingGeneratorEventArgs"/> instance.</param>
        public static void OnClosingGenerator(ClosingGeneratorEventArgs ev) => ClosingGenerator.InvokeSafely(ev);

        /// <summary>
        /// Called before a player inserts a workstation tablet into a generator.
        /// </summary>
        /// <param name="ev">The <see cref="ActivatingGeneratorEventArgs"/> instance.</param>
        public static void OnActivatingGenerator(ActivatingGeneratorEventArgs ev) => ActivatingGenerator.InvokeSafely(ev);

        /// <summary>
        /// Called before a player ejects the workstation tablet out of a generator.
        /// </summary>
        /// <param name="ev">The <see cref="StoppingGeneratorEventArgs"/> instance.</param>
        public static void OnStoppingGenerator(StoppingGeneratorEventArgs ev) => StoppingGenerator.InvokeSafely(ev);

        /// <summary>
        /// Called before a player receives a status effect.
        /// </summary>
        /// <param name="ev">The <see cref="ReceivingEffectEventArgs"/> instance.</param>
        public static void OnReceivingEffect(ReceivingEffectEventArgs ev) => ReceivingEffect.InvokeSafely(ev);

        /// <summary>
        /// Called before an user's mute status is changed.
        /// </summary>
        /// <param name="ev">The <see cref="ChangingMuteStatusEventArgs"/> instance.</param>
        public static void OnChangingMuteStatus(ChangingMuteStatusEventArgs ev) => ChangingMuteStatus.InvokeSafely(ev);

        /// <summary>
        /// Called before an user's intercom mute status is changed.
        /// </summary>
        /// <param name="ev">The <see cref="ChangingIntercomMuteStatusEventArgs"/> instance.</param>
        public static void OnChangingIntercomMuteStatus(ChangingIntercomMuteStatusEventArgs ev) => ChangingIntercomMuteStatus.InvokeSafely(ev);

        /// <summary>
        /// Called before a user's radio battery charge is changed.
        /// </summary>
        /// <param name="ev">The <see cref="UsingRadioBatteryEventArgs"/> instance.</param>
        public static void OnUsingRadioBattery(UsingRadioBatteryEventArgs ev) => UsingRadioBattery.InvokeSafely(ev);

        /// <summary>
        /// Called before a user's radio preset is changed.
        /// </summary>
        /// <param name="ev">The <see cref="ChangingRadioPresetEventArgs"/> instance.</param>
        public static void OnChangingRadioPreset(ChangingRadioPresetEventArgs ev) => ChangingRadioPreset.InvokeSafely(ev);

        /// <summary>
        /// Called before a player's MicroHID state is changed.
        /// </summary>
        /// <param name="ev">The <see cref="ChangingRadioPresetEventArgs"/> instance.</param>
        public static void OnChangingMicroHIDState(ChangingMicroHIDStateEventArgs ev) => ChangingMicroHIDState.InvokeSafely(ev);

        /// <summary>
        /// Called before a player's MicroHID energy is changed.
        /// </summary>
        /// <param name="ev">The <see cref="UsingMicroHIDEnergyEventArgs"/> instance.</param>
        public static void OnUsingMicroHIDEnergy(UsingMicroHIDEnergyEventArgs ev) => UsingMicroHIDEnergy.InvokeSafely(ev);

        /// <summary>
        /// Called before processing a hotkey.
        /// </summary>
        /// <param name="ev">The <see cref="ProcessingHotkeyEventArgs"/> instance.</param>
        public static void OnProcessingHotkey(ProcessingHotkeyEventArgs ev) => ProcessingHotkey.InvokeSafely(ev);

        /// <summary>
        /// Called before dropping ammo.
        /// </summary>
        /// <param name="ev">The <see cref="DroppingAmmoEventArgs"/> instance.</param>
        public static void OnDroppingAmmo(DroppingAmmoEventArgs ev) => DroppingAmmo.InvokeSafely(ev);

        /// <summary>
        /// Called before a player walks on a sinkhole.
        /// </summary>
        /// /// <param name="ev">The <see cref="WalkingOnSinkholeEventArgs"/> instance.</param>
        public static void OnWalkingOnSinkhole(WalkingOnSinkholeEventArgs ev) => WalkingOnSinkhole.InvokeSafely(ev);

        /// <summary>
        /// Called before a player interacts with a shooting target.
        /// </summary>
        /// <param name="ev">The <see cref="InteractingShootingTargetEventArgs"/> instance.</param>
        public static void OnInteractingShootingTarget(InteractingShootingTargetEventArgs ev) => InteractingShootingTarget.InvokeSafely(ev);

        /// <summary>
        /// Called before a player damages a shooting target.
        /// </summary>
        /// <param name="ev">The <see cref="DamagingShootingTargetEventArgs"/> instance.</param>
        public static void OnDamagingShootingTarget(DamagingShootingTargetEventArgs ev) => DamagingShootingTarget.InvokeSafely(ev);

        /// <summary>
        /// Called before a player flips a coin.
        /// </summary>
        /// <param name="ev">The <see cref="FlippingCoinEventArgs"/> instance.</param>
        public static void OnFlippingCoin(FlippingCoinEventArgs ev) => FlippingCoin.InvokeSafely(ev);

        /// <summary>
        /// Called before a player unloads a weapon.
        /// </summary>
        /// <param name="ev">The <see cref="UnloadingWeaponEventArgs"/> instance.</param>
        public static void OnUnloadingWeapon(UnloadingWeaponEventArgs ev) => UnloadingWeapon.InvokeSafely(ev);

        /// <summary>
        /// Called before a player triggers an aim action.
        /// </summary>
        /// <param name="ev">The <see cref="AimingDownSightEventArgs"/> instance.</param>
        public static void OnAimingDownSight(AimingDownSightEventArgs ev) => AimingDownSight.InvokeSafely(ev);

        /// <summary>
        /// Called before a player toggles the weapon's flashlight.
        /// </summary>
        /// <param name="ev">The <see cref="TogglingWeaponFlashlightEventArgs"/> instance.</param>
        public static void OnTogglingWeaponFlashlight(TogglingWeaponFlashlightEventArgs ev) => TogglingWeaponFlashlight.InvokeSafely(ev);

        /// <summary>
        /// Called before a player dryfires a weapon.
        /// </summary>
        /// <param name="ev">The <see cref="DryfiringWeaponEventArgs"/> instance.</param>
        public static void OnDryfiringWeapon(DryfiringWeaponEventArgs ev) => DryfiringWeapon.InvokeSafely(ev);

        /// <summary>
        /// Called before a player walks on a tantrum.
        /// </summary>
        /// /// <param name="ev">The <see cref="WalkingOnTantrumEventArgs"/> instance.</param>
        public static void OnWalkingOnTantrum(WalkingOnTantrumEventArgs ev) => WalkingOnTantrum.InvokeSafely(ev);

        /// <summary>
        /// Invoked after a player presses the voicechat key.
        /// </summary>
        /// <param name="ev">The <see cref="VoiceChattingEventArgs"/> instance.</param>
        public static void OnVoiceChatting(VoiceChattingEventArgs ev) => VoiceChatting.InvokeSafely(ev);

        /// <summary>
        /// Called before a player makes noise.
        /// </summary>
        /// <param name="ev">The <see cref="MakingNoiseEventArgs"/> instance.</param>
        public static void OnMakingNoise(MakingNoiseEventArgs ev) => MakingNoise.InvokeSafely(ev);

        /// <summary>
        /// Called before a player jumps.
        /// </summary>
        /// <param name="ev">The <see cref="JumpingEventArgs"/> instance.</param>
        public static void OnJumping(JumpingEventArgs ev) => Jumping.InvokeSafely(ev);

        /// <summary>
        /// Invoked after a player presses the transmission key.
        /// </summary>
        /// <param name="ev">The <see cref="TransmittingEventArgs"/> instance.</param>
        public static void OnTransmitting(TransmittingEventArgs ev) => Transmitting.InvokeSafely(ev);

        /// <summary>
        /// Called before a player changes move state.
        /// </summary>
        /// <param name="ev">The <see cref="ChangingMoveStateEventArgs"/> instance.</param>
        public static void OnChangingMoveState(ChangingMoveStateEventArgs ev) => ChangingMoveState.InvokeSafely(ev);

        /// <summary>
        /// Called before a player toggles the NoClip mode.
        /// </summary>
        /// <param name="ev">The <see cref="TogglingNoClipEventArgs"/> instance.</param>
        public static void OnTogglingNoClip(TogglingNoClipEventArgs ev) => TogglingNoClip.InvokeSafely(ev);
      
        /// <summary>
        /// Invoked after a player changes spectated player.
        /// </summary>
        /// <param name="ev">The <see cref="ChangingSpectatedPlayerEventArgs"/> instance.</param>
        public static void OnChangingSpectatedPlayer(ChangingSpectatedPlayerEventArgs ev) => ChangingSpectatedPlayer.InvokeSafely(ev);
    }
}
