﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SpellWork.Database;
using SpellWork.DBC.Structures;
using SpellWork.Extensions;
using SpellWork.GameTables;
using SpellWork.GameTables.Structures;

namespace SpellWork.Spell
{
    public class SpellInfo
    {
        public SpellEntry Spell { get; set; }
        public SpellAuraOptionsEntry AuraOptions { get; set; }
        public SpellAuraRestrictionsEntry AuraRestrictions { get; set; }
        public SpellCastingRequirementsEntry CastingRequirements { get; set; }
        public SpellCategoriesEntry Categories { get; set; }
        public SpellClassOptionsEntry ClassOptions { get; set; }
        public SpellCooldownsEntry Cooldowns { get; set; }
        public SpellEquippedItemsEntry EquippedItems { get; set; }
        public SpellInterruptsEntry Interrupts { get; set; }
        public SpellLevelsEntry Levels { get; set; }
        public SpellMiscEntry Misc { get; set; }
        public SpellReagentsEntry Reagents { get; set; }
        public SpellScalingEntry Scaling { get; set; }
        public SpellShapeshiftEntry Shapeshift { get; set; }
        public SynchronizedCollection<SpellTargetRestrictionsEntry> TargetRestrictions { get; } = new SynchronizedCollection<SpellTargetRestrictionsEntry>();
        public SpellTotemsEntry Totems { get; set; }
        public SpellXSpellVisualEntry SpellXSpellVisual { get; set; }
        public SynchronizedCollection<SpellEffectEntry> Effects { get; } = new SynchronizedCollection<SpellEffectEntry>(40);
        public SpellProcsPerMinuteEntry ProcsPerMinute { get; set; }
        public SpellDescriptionVariablesEntry DescriptionVariables { get; set; }
        public SpellDurationEntry DurationEntry { get; set; }
        public SpellRangeEntry Range { get; set; }

        #region SpellDuration
        public int Duration => DurationEntry?.Duration ?? 0;
        public int DurationPerLevel => DurationEntry?.DurationPerLevel ?? 0;
        public int MaxDuration => DurationEntry?.MaxDuration ?? 0;
        #endregion

        #region Spell
        public int ID => Spell.ID;
        public string Name => Spell.Name;
        public string Description => Spell.Description;
        public string Tooltip => Spell.AuraDescription;
        #endregion

        #region SpellMisc
        // SpellMisc
        public uint Attributes => Misc?.Attributes[0] ?? 0;
        public uint AttributesEx => Misc?.Attributes[1] ?? 0;
        public uint AttributesEx2 => Misc?.Attributes[2] ?? 0;
        public uint AttributesEx3 => Misc?.Attributes[3] ?? 0;
        public uint AttributesEx4 => Misc?.Attributes[4] ?? 0;
        public uint AttributesEx5 => Misc?.Attributes[5] ?? 0;
        public uint AttributesEx6 => Misc?.Attributes[6] ?? 0;
        public uint AttributesEx7 => Misc?.Attributes[7] ?? 0;
        public uint AttributesEx8 => Misc?.Attributes[8] ?? 0;
        public uint AttributesEx9 => Misc?.Attributes[9] ?? 0;
        public uint AttributesEx10 => Misc?.Attributes[10] ?? 0;
        public uint AttributesEx11 => Misc?.Attributes[11] ?? 0;
        public uint AttributesEx12 => Misc?.Attributes[12] ?? 0;
        public uint AttributesEx13 => Misc?.Attributes[13] ?? 0;
        public float Speed => Misc?.Speed ?? 0;
        public int CastingTimeIndex => Misc?.CastingTimeIndex ?? 0;
        public int ActiveIconID => Misc?.ActiveIconID ?? 0;
        public int SpellIconID => Misc?.SpellIconID ?? 0;
        public int RangeIndex => Misc?.RangeIndex ?? 0;
        public uint SchoolMask => (uint)(Misc?.SchoolMask ?? 0);
        #endregion

        #region SpellClassOptions
        // SpellClassOptions
        public uint ModalNextSpell => ClassOptions?.ModalNextSpell ?? 0;
        public uint SpellFamilyName => ClassOptions?.SpellClassSet ?? 0;
        public uint[] SpellFamilyFlags => ClassOptions?.SpellFamilyFlags ?? new uint[4];
        #endregion

        #region SpellCategories
        // SpellCategories
        public int DamageClass => Categories?.DefenseType ?? 0;
        public int PreventionType => Categories?.PreventionType ?? 0;
        public ushort Category => Categories?.Category ?? 0;
        public int Dispel => Categories?.DispelType ?? 0;
        public int Mechanic => Categories?.Mechanic ?? 0;
        #endregion

        #region SpellShapeshift
        // SpellShapeshift
        public ulong Stances => ((Shapeshift?.ShapeshiftMask[0] ?? 0) << 32) | (Shapeshift?.ShapeshiftMask[1] ?? 0);
        public ulong StancesNot => ((Shapeshift?.ShapeshiftExclude[0] ?? 0) << 32) | (Shapeshift?.ShapeshiftExclude[1] ?? 0);
        #endregion

        #region SpellCooldowns
        // SpellCooldowns
        public uint CategoryRecoveryTime => Cooldowns?.CategoryRecoveryTime ?? 0;
        public uint RecoveryTime => Cooldowns?.RecoveryTime ?? 0;
        public uint StartRecoveryTime => Cooldowns?.StartRecoveryTime ?? 0;
        public uint StartRecoveryCategory => Categories?.StartRecoveryCategory ?? 0;
        #endregion

        #region SpellAuraRestrictions
        // SpellAuraRestrictions
        public int CasterAuraState => AuraRestrictions?.CasterAuraState ?? 0;
        public int TargetAuraState => AuraRestrictions?.TargetAuraState ?? 0;
        public int CasterAuraStateNot => AuraRestrictions?.ExcludeCasterAuraState ?? 0;
        public int TargetAuraStateNot => AuraRestrictions?.ExcludeTargetAuraState ?? 0;
        public int CasterAuraSpell => (int) (AuraRestrictions?.CasterAuraSpell ?? 0);
        public int TargetAuraSpell => (int) (AuraRestrictions?.TargetAuraSpell ?? 0);
        public int ExcludeCasterAuraSpell => (int) (AuraRestrictions?.ExcludeCasterAuraSpell ?? 0);
        public int ExcludeTargetAuraSpell => (int)(AuraRestrictions?.ExcludeTargetAuraSpell ?? 0);
        #endregion

        #region SpellAuraOptions
        public uint ProcCharges => AuraOptions?.ProcCharges ?? 0;
        public uint ProcChance => AuraOptions?.ProcChance ?? 0;
        public uint ProcFlags => AuraOptions?.ProcTypeMask ?? 0;
        public uint CumulativeAura => AuraOptions?.CumulativeAura ?? 0;
        #endregion

        #region SpellLevels
        // SpellLevels
        public int BaseLevel => Levels?.BaseLevel ?? 0;
        public int MaxLevel => Levels?.MaxLevel ?? 0;
        public int SpellLevel => Levels?.SpellLevel ?? 0;
        public int MaxUsableLevel => Levels?.MaxUsableLevel ?? 0;
        #endregion

        #region EquippedItems
        // Equippeditems
        public int EquippedItemClass => EquippedItems?.EquippedItemClass ?? 0;
        public uint EquippedItemInventoryTypeMask => EquippedItems?.EquippedItemInventoryTypeMask ?? 0;
        public uint EquippedItemSubClassMask => EquippedItems?.EquippedItemSubClassMask ?? 0;
        #endregion

        #region SpellXSpellVisual
        public int SpellVisual => SpellXSpellVisual?.SpellVisualID ?? 0;
        public int ViolentSpellVisual => SpellXSpellVisual?.ViolentSpellVisualID ?? 0;
        #endregion

        #region CastingRequirements
        public uint RequiredAreasId => CastingRequirements?.RequiredAreasID ?? 0;
        public uint FacingCasterFlags => CastingRequirements?.FacingCasterFlags ?? 0;
        public uint MinFactionID => CastingRequirements?.MinFactionID ?? 0;
        public uint MinReputation => CastingRequirements?.MinReputation ?? 0;
        public uint RequiredAuraVision => CastingRequirements?.RequiredAuraVision ?? 0;
        public uint RequiresSpellFocus => CastingRequirements?.RequiresSpellFocus ?? 0;
        #endregion

        #region SpellProcsPerMinute
        public float BaseProcRate => ProcsPerMinute?.BaseProcRate ?? 0;
        public byte ProcsPerMinuteFlags => ProcsPerMinute?.Flags ?? 0;
        #endregion

        public string ProcInfo
        {
            get
            {
                var i = 0;
                var sb = new StringBuilder();
                var proc = ProcFlags;
                while (proc != 0)
                {
                    if ((proc & 1) != 0)
                        sb.AppendFormatLine("  {0}", SpellEnums.ProcFlagDesc[i]);
                    ++i;
                    proc >>= 1;
                }

                return sb.ToString();
            }
        }

        private const string Separator = "=================================================";

        public SpellInfo(SpellEntry spellEntry)
        {
            Spell = spellEntry;
            SpellDescriptionVariablesEntry variables;
            if (DBC.DBC.SpellDescriptionVariables.TryGetValue(spellEntry.DescriptionVariablesID, out variables))
                DescriptionVariables = variables;
        }

        public void Write(RichTextBox rtb)
        {
            rtb.Clear();

            rtb.SetBold();
            rtb.AppendFormatLine("ID - {0} {1}{2}",
                ID, Name, Scaling != null ? $" (Level {DBC.DBC.SelectedLevel})" : string.Empty);
            rtb.SetDefaultStyle();

            rtb.AppendFormatLine(Separator);

            rtb.AppendLine(Description);
            rtb.AppendFormatLineIfNotNull("ToolTip: {0}", Tooltip);
            if (DescriptionVariables != null)
            {
                rtb.AppendLine("Description variables:");
                rtb.AppendLine(DescriptionVariables.Variables);
            }

            rtb.AppendFormatLineIfNotNull("Modal Next Spell: {0}", ModalNextSpell);
            if (!string.IsNullOrEmpty(Spell.Description) && !string.IsNullOrEmpty(Spell.AuraDescription) && ModalNextSpell != 0)
                rtb.AppendFormatLine(Separator);

            #region Triggered by ...
            var addline = false;
            if (DBC.DBC.SpellTriggerStore.ContainsKey(Spell.ID))
            {
                foreach (var procSpellId in DBC.DBC.SpellTriggerStore[Spell.ID])
                {
                    var procname = "Spell Not Found";
                    if (DBC.DBC.Spell.ContainsKey(procSpellId))
                        procname = DBC.DBC.Spell[procSpellId].Name;
                    rtb.SetStyle(Color.Blue, FontStyle.Bold);

                    rtb.AppendFormatLine("Triggered by spell: ({0}) {1}", procSpellId, procname);
                    rtb.SetDefaultStyle();
                    addline = true;
                }
            }
            if (addline)
                rtb.AppendFormatLine(Separator);
            #endregion

            rtb.AppendFormatLine("Category = {0}, SpellIconID = {1}, activeIconID = {2}, SpellVisual = ({3}, {4})",
                Category, SpellIconID, ActiveIconID, SpellVisual, ViolentSpellVisual);

            rtb.AppendFormatLine("Family {0} ({1}), flag [0] 0x{2:X8} [1] 0x{3:X8} [2] 0x{4:X8} [3] 0x{5:X8}",
                    (SpellFamilyNames)SpellFamilyName, SpellFamilyName,
                    SpellFamilyFlags[0], SpellFamilyFlags[1], SpellFamilyFlags[2], SpellFamilyFlags[3]);

            #region Modified by ...
            foreach (var eff in
                    from s in DBC.DBC.SpellInfoStore.Values
                    where s.SpellFamilyName == SpellFamilyName
                    from eff in s.Effects
                    where eff != null && ((eff.EffectSpellClassMask[0] & SpellFamilyFlags[0]) != 0 ||
                          (eff.EffectSpellClassMask[1] & SpellFamilyFlags[1]) != 0 ||
                          (eff.EffectSpellClassMask[2] & SpellFamilyFlags[2]) != 0 ||
                          (eff.EffectSpellClassMask[3] & SpellFamilyFlags[3]) != 0)
                    select eff)
            {
                rtb.SetStyle(Color.Blue, FontStyle.Bold);
                rtb.AppendFormatLine("Modified by {0} ({1})",
                    DBC.DBC.SpellInfoStore[eff.SpellID].Spell.Name, eff.SpellID);
            }
            #endregion

            rtb.AppendLine();

            rtb.AppendFormatLine("SpellSchoolMask = {0} ({1})", (SpellSchoolMask)SchoolMask, SchoolMask);
            rtb.AppendFormatLine("DamageClass = {0} ({1})", DamageClass, (SpellDmgClass)DamageClass);
            rtb.AppendFormatLine("PreventionType = {0} ({1})", PreventionType, (SpellPreventionType)PreventionType);

            #region Attributes
            if (Misc != null && !Misc.Attributes.All(a => a == 0))
                rtb.AppendLine(Separator);

            if (Attributes != 0)
                rtb.AppendFormatLine("Attributes: 0x{0:X8} ({1})", Attributes, (SpellAtribute)Attributes);
            if (AttributesEx != 0)
                rtb.AppendFormatLine("AttributesEx1: 0x{0:X8} ({1})", AttributesEx, (SpellAtributeEx)AttributesEx);
            if (AttributesEx2 != 0)
                rtb.AppendFormatLine("AttributesEx2: 0x{0:X8} ({1})", AttributesEx2, (SpellAtributeEx2)AttributesEx2);
            if (AttributesEx3 != 0)
                rtb.AppendFormatLine("AttributesEx3: 0x{0:X8} ({1})", AttributesEx3, (SpellAtributeEx3)AttributesEx3);
            if (AttributesEx4 != 0)
                rtb.AppendFormatLine("AttributesEx4: 0x{0:X8} ({1})", AttributesEx4, (SpellAtributeEx4)AttributesEx4);
            if (AttributesEx5 != 0)
                rtb.AppendFormatLine("AttributesEx5: 0x{0:X8} ({1})", AttributesEx5, (SpellAtributeEx5)AttributesEx5);
            if (AttributesEx6 != 0)
                rtb.AppendFormatLine("AttributesEx6: 0x{0:X8} ({1})", AttributesEx6, (SpellAtributeEx6)AttributesEx6);
            if (AttributesEx7 != 0)
                rtb.AppendFormatLine("AttributesEx7: 0x{0:X8} ({1})", AttributesEx7, (SpellAtributeEx7)AttributesEx7);
            if (AttributesEx8 != 0)
                rtb.AppendFormatLine("AttributesEx8: 0x{0:X8} ({1})", AttributesEx8, (SpellAtributeEx8)AttributesEx8);
            if (AttributesEx9 != 0)
                rtb.AppendFormatLine("AttributesEx9: 0x{0:X8} ({1})", AttributesEx9, (SpellAtributeEx9)AttributesEx9);
            if (AttributesEx10 != 0)
                rtb.AppendFormatLine("AttributesEx10: 0x{0:X8} ({1})", AttributesEx10, (SpellAtributeEx10)AttributesEx10);
            if (AttributesEx11 != 0)
                rtb.AppendFormatLine("AttributesEx11: 0x{0:X8} ({1})", AttributesEx11, (SpellAtributeEx11)AttributesEx11);
            if (AttributesEx12 != 0)
                rtb.AppendFormatLine("AttributesEx12: 0x{0:X8} ({1})", AttributesEx12, (SpellAtributeEx12)AttributesEx12);
            if (AttributesEx13 != 0)
                rtb.AppendFormatLine("AttributesEx13: 0x{0:X8} ({1})", AttributesEx13, (SpellAtributeEx13)AttributesEx13);

            rtb.AppendLine(Separator);
            #endregion

            if (TargetRestrictions != null)
            {
                foreach (var targetRestriction in TargetRestrictions)
                {
                    if (targetRestriction.Targets != 0)
                        rtb.AppendFormatLine("Targets Mask = 0x{0:X8} ({1})", targetRestriction.Targets, (SpellCastTargetFlags)targetRestriction.Targets);

                    if (targetRestriction.TargetCreatureType != 0)
                        rtb.AppendFormatLine("Creature Type Mask = 0x{0:X8} ({1})",
                            targetRestriction.TargetCreatureType, (CreatureTypeMask)targetRestriction.TargetCreatureType);

                    if (targetRestriction.MaxAffectedTargets != 0)
                        rtb.AppendFormatLine("MaxAffectedTargets: {0}", targetRestriction.MaxAffectedTargets);
                }
            }

            if (Stances != 0)
                rtb.AppendFormatLine("Stances: {0}", (ShapeshiftFormMask)Stances);

            if (StancesNot != 0)
                rtb.AppendFormatLine("Stances Not: {0}", (ShapeshiftFormMask)StancesNot);

            // Skills
            {
                var query = DBC.DBC.SkillLineAbility.Where(skl => skl.Value.SpellID == Spell.ID).ToArray();
                if (query.Length != 0)
                {
                    var skill = query.First().Value;
                    var line = DBC.DBC.SkillLine[skill.SkillLine];

                    rtb.AppendFormatLine(@"Skill (Id {0}) ""{1}""", skill.SkillLine, line.DisplayName);
                    rtb.AppendFormat("    MinSkillLineRank {0}", skill.MinSkillLineRank);

                    rtb.AppendFormat(", SupercedesSpell = {0}, MinMaxValue ({1}, {2})", skill.SupercedesSpell,
                        skill.TrivialSkillLineRankLow, skill.TrivialSkillLineRankHigh);
                    rtb.AppendFormat(", NumSkillups ({0})", skill.NumSkillUps);
                }
            }

            // SpellReagents
            {
                var printedHeader = false;
                for (var i = 0; Reagents != null && i < Reagents.ReagentCount.Length; ++i)
                {
                    if (Reagents.ReagentCount[i] == 0 || Reagents.Reagent[i] == 0)
                        continue;

                    if (!printedHeader)
                    {
                        rtb.AppendLine();
                        rtb.Append("Reagents:");
                        printedHeader = true;
                    }

                    rtb.AppendFormat("  {0} x{1}", Reagents.Reagent[i], Reagents.ReagentCount[i]);
                }

                if (printedHeader)
                    rtb.AppendLine();
            }

            rtb.AppendFormatLine("Spell Level = {0}, base {1}, max {2}, max usable {3}",
                SpellLevel, BaseLevel, MaxLevel, MaxUsableLevel);

            if (EquippedItemClass != 0)
            {
                rtb.AppendFormatLine("EquippedItemClass = {0} ({1})", EquippedItemClass, (ItemClass)EquippedItemClass);

                if (EquippedItemSubClassMask != 0)
                {
                    switch ((ItemClass)EquippedItemClass)
                    {
                        case ItemClass.WEAPON:
                            rtb.AppendFormatLine("    SubClass mask 0x{0:X8} ({1})", EquippedItemSubClassMask, (ItemSubClassWeaponMask)EquippedItemSubClassMask);
                            break;
                        case ItemClass.ARMOR:
                            rtb.AppendFormatLine("    SubClass mask 0x{0:X8} ({1})", EquippedItemSubClassMask, (ItemSubClassArmorMask)EquippedItemSubClassMask);
                            break;
                        case ItemClass.MISC:
                            rtb.AppendFormatLine("    SubClass mask 0x{0:X8} ({1})", EquippedItemSubClassMask, (ItemSubClassMiscMask)EquippedItemSubClassMask);
                            break;
                    }
                }

                if (EquippedItemInventoryTypeMask != 0)
                    rtb.AppendFormatLine("    InventoryType mask = 0x{0:X8} ({1})", EquippedItemInventoryTypeMask, (InventoryTypeMask)EquippedItemInventoryTypeMask);
            }

            rtb.AppendLine();
            rtb.AppendFormatLine("Category = {0}", Category);
            rtb.AppendFormatLine("DispelType = {0} ({1})", Dispel, (DispelType)Dispel);
            rtb.AppendFormatLine("Mechanic = {0} ({1})", Mechanic, (Mechanics)Mechanic);

            if (Range != null)
            {
                rtb.AppendFormatLine("SpellRange: (Id {0}) \"{1}\":", RangeIndex, Range.DisplayName);
                rtb.AppendFormatLine("    MinRangeNegative = {0}, MinRangePositive = {1}", Range.MinRange[0], Range.MinRange[1]);
                rtb.AppendFormatLine("    MaxRangeNegative = {0}, MaxRangePositive = {1}", Range.MaxRange[0], Range.MaxRange[1]);
            }

            if (Misc != null)
                rtb.AppendFormatLineIfNotNull("Speed {0:F}", Speed);

            rtb.AppendFormatLineIfNotNull("Stackable up to {0}", ProcCharges);

            if (CastingTimeIndex != 0)
            {
                var castTimeEntry = DBC.DBC.SpellCastTimes[CastingTimeIndex];

                var level = DBC.DBC.SelectedLevel;
                if (Scaling != null && level > Scaling.MaxScalingLevel)
                    level = Scaling.MaxScalingLevel;

                if (((SpellAtributeEx13)AttributesEx13).HasFlag(SpellAtributeEx13.SPELL_ATTR13_UNK17))
                    level *= 5;

                if (Scaling != null && level > Scaling.MaxScalingLevel)
                    level = Scaling.MaxScalingLevel;

                if (Levels != null && Levels.BaseLevel != 0)
                    level -= Levels.BaseLevel;

                if (Scaling != null && level < Scaling.MinScalingLevel)
                    level = Scaling.MinScalingLevel;

                var castTime = castTimeEntry.CastTime + castTimeEntry.CastTimePerLevel * level;
                if (castTime < castTimeEntry.MinCastTime)
                    castTime = castTimeEntry.MinCastTime;

                rtb.AppendFormatLine("Cast Time: (ID {0}): {1}", CastingTimeIndex, castTime);
            }

            if (RecoveryTime != 0 || CategoryRecoveryTime != 0 || StartRecoveryCategory != 0)
            {
                rtb.AppendFormatLine("RecoveryTime: {0} ms, CategoryRecoveryTime: {1} ms", RecoveryTime, CategoryRecoveryTime);
                rtb.AppendFormatLine("StartRecoveryCategory = {0}, StartRecoveryTime = {1:F} ms", StartRecoveryCategory, StartRecoveryTime);
            }

            if (DurationEntry != null)          
                rtb.AppendFormatLine("Duration {0}, {1}, {2}", Duration, DurationPerLevel, MaxDuration);

            if (Interrupts != null)
                rtb.AppendFormatLine("Interrupt Flags: 0x{0:X8}, AuraIF 0x{1:X8} 0x{2:X8}, ChannelIF 0x{3:X8} 0x{4:X8}",
                    Interrupts.InterruptFlags, Interrupts.AuraInterruptFlags[0], Interrupts.AuraInterruptFlags[1], Interrupts.ChannelInterruptFlags[0], Interrupts.ChannelInterruptFlags[1]);

            if (CasterAuraState != 0)
                rtb.AppendFormatLine("CasterAuraState = {0} ({1})", CasterAuraState, (AuraState)CasterAuraState);

            if (TargetAuraState != 0)
                rtb.AppendFormatLine("TargetAuraState = {0} ({1})", TargetAuraState, (AuraState)TargetAuraState);

            if (CasterAuraStateNot != 0)
                rtb.AppendFormatLine("CasterAuraStateNot = {0} ({1})", CasterAuraStateNot, (AuraState)CasterAuraStateNot);

            if (TargetAuraStateNot != 0)
                rtb.AppendFormatLine("TargetAuraStateNot = {0} ({1})", TargetAuraStateNot, (AuraState)TargetAuraStateNot);

            if (CasterAuraSpell != 0)
            {
                if (DBC.DBC.SpellInfoStore.ContainsKey(CasterAuraSpell))
                    rtb.AppendFormatLine("  Caster Aura Spell ({0}) {1}", CasterAuraSpell, DBC.DBC.SpellInfoStore[CasterAuraSpell].Spell.Name);
                else
                    rtb.AppendFormatLine("  Caster Aura Spell ({0}) ?????", CasterAuraSpell);
            }

            if (TargetAuraSpell != 0)
            {
                if (DBC.DBC.SpellInfoStore.ContainsKey(TargetAuraSpell))
                    rtb.AppendFormatLine("  Target Aura Spell ({0}) {1}", TargetAuraSpell, DBC.DBC.SpellInfoStore[TargetAuraSpell].Spell.Name);
                else
                    rtb.AppendFormatLine("  Target Aura Spell ({0}) ?????", TargetAuraSpell);
            }

            if (ExcludeCasterAuraSpell != 0)
            {
                if (DBC.DBC.SpellInfoStore.ContainsKey(ExcludeCasterAuraSpell))
                    rtb.AppendFormatLine("  Ex Caster Aura Spell ({0}) {1}", ExcludeCasterAuraSpell, DBC.DBC.SpellInfoStore[ExcludeCasterAuraSpell].Spell.Name);
                else
                    rtb.AppendFormatLine("  Ex Caster Aura Spell ({0}) ?????", ExcludeCasterAuraSpell);
            }

            if (ExcludeTargetAuraSpell != 0)
            {
                if (DBC.DBC.SpellInfoStore.ContainsKey(ExcludeTargetAuraSpell))
                    rtb.AppendFormatLine("  Ex Target Aura Spell ({0}) {1}", ExcludeTargetAuraSpell, DBC.DBC.SpellInfoStore[ExcludeTargetAuraSpell].Spell.Name);
                else
                    rtb.AppendFormatLine("  Ex Target Aura Spell ({0}) ?????", ExcludeTargetAuraSpell);
            }

            if (RequiredAreasId > 0)
            {
                var areas = DBC.DBC.AreaGroupMember.Values.Where(ag => ag.AreaGroupId == RequiredAreasId).ToList();
                if (areas.Count == 0)
                    rtb.AppendFormatLine("Cannot find area group id {0} in AreaGroupMember.db2!", RequiredAreasId);
                else
                {
                    rtb.AppendLine();
                    rtb.SetBold();
                    rtb.AppendLine("Allowed areas:");
                    foreach (var areaGroupMember in areas)
                    {
                        var areaId = areaGroupMember.AreaId;
                        if (!DBC.DBC.AreaTable.ContainsKey(areaId))
                            continue;

                        var areaEntry = DBC.DBC.AreaTable[areaId];
                        rtb.AppendFormatLine("{0} - {1} (Map: {2})", areaId, areaEntry.AreaName, areaEntry.MapID);
                    }

                    rtb.AppendLine();
                }
            }

            rtb.AppendFormatLineIfNotNull("Requires Spell Focus {0}", RequiresSpellFocus);

            if (Math.Abs(BaseProcRate) > 1.0E-5f)
            {
                rtb.SetBold();
                rtb.AppendFormatLine("PPM flag 0x{0:X2} BaseRate {1}", ProcsPerMinuteFlags, BaseProcRate);
                rtb.SetDefaultStyle();
            }

            if (ProcFlags != 0)
            {
                rtb.SetBold();
                rtb.AppendFormatLine("Proc flag 0x{0:X8}, chance = {1}, charges - {2}",
                    ProcFlags, ProcChance, ProcCharges);
                rtb.SetDefaultStyle();
                rtb.AppendFormatLine(Separator);
                rtb.AppendText(ProcInfo);
            }
            else
                rtb.AppendFormatLine("Chance = {0}, charges - {1}", ProcChance, ProcCharges);

            rtb.AppendLine(Separator);
            foreach (var effect in Effects)
                AppendEffectInfo(rtb, effect);

            AppendItemInfo(rtb);

            AppendSpellVisualInfo();
        }

        private void AppendEffectInfo(RichTextBox rtb, SpellEffectEntry effect)
        {
            rtb.SetBold();
            rtb.AppendFormatLine("Effect {0}: Id {1} ({2}) {3}", effect.EffectIndex, effect.Effect, (SpellEffects)effect.Effect, (Difficulty)effect.DifficultyID);
            rtb.SetDefaultStyle();

            var value = 0.0f;

            if (effect.SpellEffectScalingEntry != null &&
                Math.Abs(effect.SpellEffectScalingEntry.Coefficient) > 1.0E-5f &&
                Scaling != null &&
                Scaling.ScalingClass != 0)
            {
                var level = (int)(DBC.DBC.SelectedLevel - 1);
                if ((AttributesEx11 & (uint)SpellAtributeEx11.SPELL_ATTR11_SCALES_WITH_ITEM_LEVEL) == 0)
                {
                    if ((AttributesEx10 & (uint)SpellAtributeEx10.SPELL_ATTR10_USE_SPELL_BASE_LEVEL_FOR_SCALING) != 0)
                        level = BaseLevel;
                }
                else
                    level = (int)DBC.DBC.SelectedItemLevel;

                if (Scaling.MaxScalingLevel != 0 && Scaling.MaxScalingLevel > level)
                    level = (int)Scaling.MaxScalingLevel;

                if (level < 1)
                    level = 1;

                if (Scaling.ScalingClass != 0)
                {

                    if (Scaling.ScalesFromItemLevel == 0)
                    {
                        if ((AttributesEx11 & (uint)SpellAtributeEx11.SPELL_ATTR11_SCALES_WITH_ITEM_LEVEL) == 0)
                        {
                            var gtScaling = GameTable<GtSpellScalingEntry>.GetRecord((int)level);
                            value = Scaling.ScalingClass > 0
                                ? gtScaling.GetColumnForClass(Scaling.ScalingClass)
                                : gtScaling.Item;
                        }
                        else if (DBC.DBC.RandPropPoints.ContainsKey(level))
                        {
                            var randPropPoints = DBC.DBC.RandPropPoints[level];
                            value = randPropPoints.Superior[0];
                        }
                    }
                    else
                    {
                        if (DBC.DBC.RandPropPoints.ContainsKey(Scaling.ScalesFromItemLevel))
                        {
                            var randPropPoints = DBC.DBC.RandPropPoints[Scaling.ScalesFromItemLevel];
                            value = randPropPoints.Superior[0];
                        }
                    }

                    // if (level < Scaling.CastTimeMaxLevel && Scaling.CastTimeMax != 0)
                    //     value *= (float)(Scaling.CastTimeMin + (level - 1) * (Scaling.CastTimeMax - Scaling.CastTimeMin) / (Scaling.CastTimeMaxLevel - 1)) / (Scaling.CastTimeMax);

                    // if (level < Scaling.NerfMaxLevel)
                    //     value *= ((((1.0f - Scaling.NerfFactor) * (level - 1)) / (Scaling.NerfMaxLevel - 1)) + Scaling.NerfFactor);
                }

                value *= effect.SpellEffectScalingEntry.Coefficient;
                if (Math.Abs(value) > 1.0E-5f && value < 1.0f)
                    value = 1.0f;

                if (Math.Abs(effect.SpellEffectScalingEntry.Variance) > 1.0E-5f)
                {
                    var delta = Math.Abs(value * effect.SpellEffectScalingEntry.Variance * 0.5f);
                    rtb.AppendFormat("BasePoints = {0:F} to {1:F}", value - delta, value + delta);
                }
                else
                    rtb.AppendFormat("BasePoints = {0:F}", value);

                if (Math.Abs(effect.SpellEffectScalingEntry.ResourceCoefficient) > 1.0E-5f)
                    rtb.AppendFormatIfNotNull(" + combo * {0:F}", effect.SpellEffectScalingEntry.ResourceCoefficient * value);
            }
            else
            {
                rtb.AppendFormat("BasePoints = {0}", effect.EffectBasePoints + (effect.EffectDieSides == 0 ? 0 : 1));

                if (Math.Abs(effect.EffectRealPointsPerLevel) > 1.0E-5f)
                    rtb.AppendFormat(" + Level * {0:F}", effect.EffectRealPointsPerLevel);

                if (effect.EffectDieSides > 1)
                {
                    if (Math.Abs(effect.EffectRealPointsPerLevel) > 1.0E-5f)
                        rtb.AppendFormat(" to {0} + lvl * {1:F}",
                            effect.EffectBasePoints + effect.EffectDieSides, effect.EffectRealPointsPerLevel);
                    else
                        rtb.AppendFormat(" to {0}", effect.EffectBasePoints + effect.EffectDieSides);
                }

                rtb.AppendFormatIfNotNull(" + resource * {0:F}", effect.EffectPointsPerResource);
            }

            if (effect.EffectBonusCoefficient > 1.0E-5f)
                rtb.AppendFormat(" + spellPower * {0}", effect.EffectBonusCoefficient);

            if (effect.BonusCoefficientFromAP > 1.0E-5)
                rtb.AppendFormat(" + AP * {0}", effect.BonusCoefficientFromAP);

            // if (Math.Abs(effect.DamageMultiplier - 1.0f) > 1.0E-5f)
            //     rtb.AppendFormat(" x {0:F}", effect.DamageMultiplier);

            // rtb.AppendFormatIfNotNull("  Multiple = {0:F}", effect.ValueMultiplier);
            rtb.AppendLine();

            rtb.AppendFormatLine("Targets ({0}, {1}) ({2}, {3})",
                effect.ImplicitTarget[0], effect.ImplicitTarget[1],
                (Targets)effect.ImplicitTarget[0], (Targets)effect.ImplicitTarget[1]);

            AuraModTypeName(rtb, effect);

            var classMask = effect.EffectSpellClassMask;

            if (classMask[0] != 0 || classMask[1] != 0 || classMask[2] != 0 || classMask[3] != 0)
            {
                rtb.AppendFormatLine("SpellClassMask = {0:X8} {1:X8} {2:X8} {3:X8}", classMask[0], classMask[1], classMask[2], classMask[3]);

                var query = from spell in DBC.DBC.SpellInfoStore.Values
                            where spell.SpellFamilyName == SpellFamilyName && spell.SpellFamilyFlags.ContainsElement(classMask)
                            join sk in DBC.DBC.SkillLineAbility.Values on spell.ID equals sk.SpellID into temp
                            from skill in temp.DefaultIfEmpty(new SkillLineAbilityEntry())
                            select new
                            {
                                SpellID = spell.Spell.ID,
                                SpellName = spell.Spell.Name,
                                SkillId = skill.SkillLine
                            };

                foreach (var row in query)
                {
                    if (row.SkillId > 0)
                    {
                        rtb.SelectionColor = Color.Blue;
                        rtb.AppendFormatLine("\t+ {0} - {1}", row.SpellID, row.SpellName);
                    }
                    else
                    {
                        rtb.SelectionColor = Color.Red;
                        rtb.AppendFormatLine("\t- {0} - {1}", row.SpellID, row.SpellName);
                    }
                    rtb.SelectionColor = Color.Black;
                }
            }

            rtb.AppendFormatLineIfNotNull("{0}", effect.Radius);
            rtb.AppendFormatLineIfNotNull("{0}", effect.MaxRadius);

            // append trigger spell
            var trigger = effect.EffectTriggerSpell;
            if (trigger != 0)
            {
                if (DBC.DBC.SpellInfoStore.ContainsKey((int)trigger))
                {
                    var triggerSpell = DBC.DBC.SpellInfoStore[(int)trigger];
                    rtb.SetStyle(Color.Blue, FontStyle.Bold);
                    rtb.AppendFormatLine("   Trigger spell ({0}) {1}. Chance = {2}", trigger, triggerSpell.Spell.Name, ProcChance);
                    rtb.AppendFormatLineIfNotNull("   Description: {0}", triggerSpell.Spell.Description);
                    rtb.AppendFormatLineIfNotNull("   ToolTip: {0}", triggerSpell.Spell.AuraDescription);
                    rtb.SetDefaultStyle();
                    if (triggerSpell.ProcFlags != 0)
                    {
                        rtb.AppendFormatLine("Charges - {0}", triggerSpell.ProcCharges);
                        rtb.AppendLine(Separator);
                        rtb.AppendLine(triggerSpell.ProcInfo);
                        rtb.AppendLine(Separator);
                    }
                }
                else
                    rtb.AppendFormatLine("Trigger spell ({0}) Not found, Chance = {1}", trigger, ProcChance);
            }

            rtb.AppendFormatLineIfNotNull("EffectChainTargets = {0}", effect.EffectChainTargets);
            rtb.AppendFormatLineIfNotNull("EffectItemType = {0}", effect.EffectItemType);

            if ((Mechanics)effect.EffectMechanic != Mechanics.MECHANIC_NONE)
                rtb.AppendFormatLine("Effect Mechanic = {0} ({1})", effect.EffectMechanic, (Mechanics)effect.EffectMechanic);

            rtb.AppendFormatLineIfNotNull("Attributes {0:X8} ({0})", effect.EffectAttributes);
            rtb.AppendLine();
        }

        private static void AuraModTypeName(RichTextBox rtb, SpellEffectEntry effect)
        {
            var aura = (AuraType)effect.EffectAura;
            var misc = effect.EffectMiscValues[0];

            if (effect.EffectAura == 0)
            {
                rtb.AppendFormatLineIfNotNull("EffectMiscValueA = {0}", effect.EffectMiscValues[0]);
                rtb.AppendFormatLineIfNotNull("EffectMiscValueB = {0}", effect.EffectMiscValues[1]);
                rtb.AppendFormatLineIfNotNull("EffectAmplitude = {0}", effect.EffectAmplitude);

                return;
            }

            rtb.AppendFormat("Aura Id {0:D} ({0})", aura);
            rtb.AppendFormat(", value = {0}", effect.EffectBasePoints);
            rtb.AppendFormat(", misc = {0} (", misc);

            switch (aura)
            {
                case AuraType.SPELL_AURA_MOD_STAT:
                    rtb.Append((UnitMods)misc);
                    break;
                case AuraType.SPELL_AURA_MOD_RATING:
                case AuraType.SPELL_AURA_MOD_RATING_PCT:
                    rtb.Append((CombatRating)misc);
                    break;
                case AuraType.SPELL_AURA_ADD_FLAT_MODIFIER:
                case AuraType.SPELL_AURA_ADD_PCT_MODIFIER:
                    rtb.Append((SpellModOp)misc);
                    break;
                // TODO: more case
                default:
                    rtb.Append(misc);
                    break;
            }

            rtb.AppendFormat("), miscB = {0}", effect.EffectMiscValues[1]);
            rtb.AppendFormatLine(", periodic = {0}", effect.EffectAmplitude);

            switch (aura)
            {
                case AuraType.SPELL_AURA_OVERRIDE_SPELLS:
                    if (!DBC.DBC.OverrideSpellData.ContainsKey(misc))
                    {
                        rtb.SetStyle(Color.Red, FontStyle.Bold);
                        rtb.AppendFormatLine("Cannot find key {0} in OverrideSpellData.dbc", (uint)misc);
                    }
                    else
                    {
                        rtb.AppendLine();
                        rtb.SetStyle(Color.DarkRed, FontStyle.Bold);
                        var @override = DBC.DBC.OverrideSpellData[misc];
                        for (var i = 0; i < 10; ++i)
                        {
                            if (@override.Spells[i] == 0)
                                continue;

                            rtb.SetStyle(Color.DarkBlue, FontStyle.Regular);
                            rtb.AppendFormatLine("\t - #{0} ({1}) {2}", i + 1, @override.Spells[i],
                                DBC.DBC.SpellInfoStore.ContainsKey((int)@override.Spells[i]) ? DBC.DBC.SpellInfoStore[(int)@override.Spells[i]].Name : "?????");
                        }
                        rtb.AppendLine();
                    }
                    break;
                case AuraType.SPELL_AURA_SCREEN_EFFECT:
                    rtb.SetStyle(Color.DarkBlue, FontStyle.Bold);
                    rtb.AppendFormatLine("ScreenEffect: {0}",
                        DBC.DBC.ScreenEffect.ContainsKey(misc) ? DBC.DBC.ScreenEffect[misc].Name : "?????");
                    break;
            }
        }

        private void AppendItemInfo(RichTextBox rtb)
        {
            var items = from item in DBC.DBC.ItemTemplate
                        where item.SpellId.ContainsElement((int)ID)
                        select item;

            // ReSharper disable once PossibleMultipleEnumeration
            var enumerable = items as Item[] ?? items.ToArray();
            if (!enumerable.Any())
                return;

            rtb.AppendLine(Separator);
            rtb.SetStyle(Color.Blue, FontStyle.Bold);
            rtb.AppendLine("Items using this spell:");
            rtb.SetDefaultStyle();

            foreach (var item in enumerable)
            {
                var name = string.IsNullOrEmpty(item.LocalesName) ? item.Name : item.LocalesName;
                var desc = string.IsNullOrEmpty(item.LocalesDescription) ? item.Description : item.LocalesDescription;

                desc = string.IsNullOrEmpty(desc) ? string.Empty : $" - \"{desc}\"";

                rtb.AppendFormatLine(@"   {0}: {1} {2}", item.Entry, name, desc);
            }
        }

        private void AppendSpellVisualInfo()
        {
            /*SpellVisualEntry visualData;
            if (!DBC.DBC.SpellVisual.TryGetValue(_spell.SpellVisual[0], out visualData))
                return;

            SpellMissileEntry missileEntry;
            SpellMissileMotionEntry missileMotionEntry;
            var hasMissileEntry = DBC.DBC.SpellMissile.TryGetValue(visualData.MissileModel, out missileEntry);
            var hasMissileMotion = DBC.DBC.SpellMissileMotion.TryGetValue(visualData.MissileMotionId, out missileMotionEntry);

            if (!hasMissileEntry && !hasMissileMotion)
                return;

            _rtb.AppendLine(_line);
            _rtb.SetBold();
            _rtb.AppendLine("Missile data");
            _rtb.SetDefaultStyle();

            // Missile Model Data.
            if (hasMissileEntry)
            {
                _rtb.AppendFormatLine("Missile Model ID: {0}", visualData.MissileModel);
                _rtb.AppendFormatLine("Missile attachment: {0}", visualData.MissileAttachment);
                _rtb.AppendFormatLine("Missile cast offset: X:{0} Y:{1} Z:{2}", visualData.MissileCastOffsetX, visualData.MissileCastOffsetY, visualData.MissileCastOffsetZ);
                _rtb.AppendFormatLine("Missile impact offset: X:{0} Y:{1} Z:{2}", visualData.MissileImpactOffsetX, visualData.MissileImpactOffsetY, visualData.MissileImpactOffsetZ);
                _rtb.AppendFormatLine("MissileEntry ID: {0}", missileEntry.Id);
                _rtb.AppendFormatLine("Collision Radius: {0}", missileEntry.CollisionRadius);
                _rtb.AppendFormatLine("Default Pitch: {0} - {1}", missileEntry.DefaultPitchMin, missileEntry.DefaultPitchMax);
                _rtb.AppendFormatLine("Random Pitch: {0} - {1}", missileEntry.RandomizePitchMax, missileEntry.RandomizePitchMax);
                _rtb.AppendFormatLine("Default Speed: {0} - {1}", missileEntry.DefaultSpeedMin, missileEntry.DefaultSpeedMax);
                _rtb.AppendFormatLine("Randomize Speed: {0} - {1}", missileEntry.RandomizeSpeedMin, missileEntry.RandomizeSpeedMax);
                _rtb.AppendFormatLine("Gravity: {0}", missileEntry.Gravity);
                _rtb.AppendFormatLine("Maximum duration:", missileEntry.MaxDuration);
                _rtb.AppendLine("");
            }

            // Missile Motion Data.
            if (hasMissileMotion)
            {
                _rtb.AppendFormatLine("Missile motion: {0}", missileMotionEntry.Name);
                _rtb.AppendFormatLine("Missile count: {0}", missileMotionEntry.MissileCount);
                _rtb.AppendLine("Missile Script body:");
                _rtb.AppendText(missileMotionEntry.Script);
            }*/
        }

        public bool HasEffect(SpellEffects effect)
        {
            return Effects.Any(eff => eff != null && eff.Effect == (uint)effect);
        }

        public bool HasAura(AuraType aura)
        {
            return Effects.Any(eff => eff != null && eff.EffectAura == (uint)aura);
        }

        public bool HasTargetA(Targets target)
        {
            return Effects.Any(eff => eff != null && eff.ImplicitTarget[0] == (uint)target);
        }

        public bool HasTargetB(Targets target)
        {
            return Effects.Any(eff => eff != null && eff.ImplicitTarget[1] == (uint)target);
        }
    }
}
