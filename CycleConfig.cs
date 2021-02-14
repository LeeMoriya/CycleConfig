using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OptionalUI;
using UnityEngine;
using RWCustom;

public class CycleConfig : OptionInterface
{
    public OpRect cycleRect;
    public OpRect lengthRect;
    public OpLabel title;
    public OpLabel hunterCycles;
    public OpLabel cycleLength;
    public OpLabel description;
    public OpLabel startCycles;
    public OpLabel pebblesCycles;
    public OpLabel presetTitle;
    public OpLabel presetDescription;
    public OpTextBox startBox;
    public OpTextBox pebblesBox;
    public OpSimpleButton presetDefault;
    public OpSimpleButton presetEasy;
    public OpSimpleButton presetHard;
    public OpSimpleButton presetCure;
    public OpLabel credits;
    public OpSlider minCycleSlider;
    public OpSlider maxCycleSlider;
    public OpSlider fixedCycleSlider;
    public OpLabel timeLabel;
    public OpSimpleButton rangeButton;
    public OpSimpleButton fixedButton;
    public OpCheckBox hunterToggle;
    public OpCheckBox lengthToggle;
    public OpLabel lengthDescription;
    public OpCheckBox fixedLength;

    public CycleConfig() : base(mod: CycleMod.mod)
    {

    }

    public override void Initialize()
    {
        //Tabs
        this.Tabs = new OpTab[1];
        this.Tabs[0] = new OpTab("Config");
        this.cycleRect = new OpRect(new Vector2(50f, 325f), new Vector2(500f, 250f), 0.3f);
        //Labels
        Vector2 rectPos = new Vector2(this.cycleRect.GetPos().x - 10f, this.cycleRect.GetPos().y - 5f);
        this.hunterCycles = new OpLabel(rectPos + new Vector2(23f, this.cycleRect.size.y - 25f), new Vector2(0f, 0f), "HUNTER CYCLES", FLabelAlignment.Left, true);
        this.startCycles = new OpLabel(new Vector2(rectPos.x + (this.cycleRect.size.x / 2 - 80f), rectPos.y + this.cycleRect.size.y - 180f), new Vector2(0f, 0f), "Starting Cycles", FLabelAlignment.Center, false);
        this.pebblesCycles = new OpLabel(new Vector2(rectPos.x + (this.cycleRect.size.x / 2 + 80f), rectPos.y + this.cycleRect.size.y - 180f), new Vector2(0f, 0f), "Pebbles Cycles", FLabelAlignment.Center, false);
        this.hunterToggle = new OpCheckBox(rectPos + new Vector2(this.cycleRect.size.x - 25f, this.cycleRect.size.y - 30f), "hunterToggle", true);
        this.hunterToggle.description = "Toggle custom Hunter cycles";
        this.Tabs[0].AddItems(this.cycleRect, this.hunterCycles, this.startCycles, this.pebblesCycles, this.hunterToggle);
        //Textboxes
        this.startBox = new OpTextBox(startCycles.GetPos() + new Vector2(-30f, -25f), 80f, "startCycle", "19", OpTextBox.Accept.Int);
        this.pebblesBox = new OpTextBox(pebblesCycles.GetPos() + new Vector2(-30f, -25f), 80f, "pebblesCycle", "5", OpTextBox.Accept.Int);
        this.Tabs[0].AddItems(this.startBox, this.pebblesBox);
        //Presets
        Vector2 presetPos = new Vector2(rectPos.x + 55f, rectPos.y + 90f);
        this.presetDescription = new OpLabel(rectPos + new Vector2(this.cycleRect.size.x / 2, this.cycleRect.size.y - 74f), new Vector2(0f, 0f), "Choose a preset below or type in the desired cycle count.", FLabelAlignment.Center, false);
        this.presetDefault = new OpSimpleButton(presetPos + new Vector2(30f, 30f), new Vector2(80f, 30f), "default", "DEFAULT");
        this.presetDefault.description = "Reset cycle numbers to their defaults";
        this.presetEasy = new OpSimpleButton(presetPos + new Vector2(120f, 30f), new Vector2(80f, 30f), "easy", "EASY");
        this.presetEasy.description = "Start with more cycles, and recieve more from Five Pebbles";
        this.presetHard = new OpSimpleButton(presetPos + new Vector2(210f, 30f), new Vector2(80f, 30f), "hard", "HARD");
        this.presetHard.description = "Start with less cycles, and recieve less from Five Pebbles";
        this.presetCure = new OpSimpleButton(presetPos + new Vector2(300f, 30f), new Vector2(80f, 30f), "cure", "CURE");
        this.presetCure.description = "Start with the default number of cycles, but visiting Five Pebbles will essentially cure Hunter's illness";
        //Credits
        this.Tabs[0].AddItems(this.presetDescription, this.presetDefault, this.presetEasy, this.presetHard, this.presetCure);

        //Cycle Length
        this.lengthRect = new OpRect(new Vector2(50f, 30f), new Vector2(500f, 270f), 0.3f);
        Vector2 rect2Pos = new Vector2(this.lengthRect.GetPos().x - 10f, this.lengthRect.GetPos().y - 5f);
        this.cycleLength = new OpLabel(rect2Pos + new Vector2(23f, this.lengthRect.size.y - 25f), new Vector2(0f, 0f), "CYCLE LENGTH", FLabelAlignment.Left, true);

        this.minCycleSlider = new OpSlider(rect2Pos + new Vector2(50f, this.lengthRect.size.y - 170f), "minLength", new IntVector2(2, 60), 7f, false, 12);
        this.minCycleSlider.colorEdge = new Color(0f, 1f, 0f);
        this.maxCycleSlider = new OpSlider(rect2Pos + new Vector2(50f, this.lengthRect.size.y - 210f), "maxLength", new IntVector2(2, 60), 7f, false, 26);
        this.maxCycleSlider.colorEdge = new Color(1f, 0f, 0f);
        this.fixedCycleSlider = new OpSlider(rect2Pos + new Vector2(50f, this.lengthRect.size.y - 185f), "fixedLength", new IntVector2(2, 61), 7f, false, 20);
        this.fixedCycleSlider.colorEdge = new Color(0.1f, 0.1f, 1f);

        this.rangeButton = new OpSimpleButton(rect2Pos + new Vector2(50f, this.lengthRect.size.y - 115f), new Vector2(70f, 30f), "range", "RANGE");
        this.fixedButton = new OpSimpleButton(rect2Pos + new Vector2(130f, this.lengthRect.size.y - 115f), new Vector2(70f, 30f), "fixed", "FIXED");
        this.timeLabel = new OpLabel(rect2Pos + new Vector2(this.lengthRect.size.x / 2, this.lengthRect.size.y - 245f), new Vector2(0f, 0f), "X MINUTES", FLabelAlignment.Center, true);
        this.lengthToggle = new OpCheckBox(rect2Pos + new Vector2(this.lengthRect.size.x - 25f, this.lengthRect.size.y - 30f), "lengthToggle", true);
        this.lengthToggle.description = "Toggle custom cycle length";
        this.lengthDescription = new OpLabel(rect2Pos + new Vector2(50f, this.lengthRect.size.y - 70f), new Vector2(0f, 0f), "Adjust the possible length a cycle can be or set a fixed length.", FLabelAlignment.Left, false);
        this.fixedLength = new OpCheckBox(new Vector2(0f, -1000f), "fixedCycle", false);

        this.Tabs[0].AddItems(this.lengthRect, this.cycleLength, this.fixedLength, this.minCycleSlider, this.maxCycleSlider, this.timeLabel, this.rangeButton, this.lengthToggle, this.fixedButton, this.fixedCycleSlider, this.lengthDescription);
    }

    public override void Update(float dt)
    {
        base.Update(dt);
        if (minCycleSlider.held && minCycleSlider.valueInt >= maxCycleSlider.valueInt - 2)
        {
            minCycleSlider.valueInt = maxCycleSlider.valueInt - 2;
        }
        if (maxCycleSlider.held && maxCycleSlider.valueInt <= minCycleSlider.valueInt + 2)
        {
            maxCycleSlider.valueInt = minCycleSlider.valueInt + 2;
        }
        if (minCycleSlider.valueInt > 58)
        {
            minCycleSlider.valueInt = 58;
        }
        if (maxCycleSlider.valueInt < 2)
        {
            maxCycleSlider.valueInt = 2;
        }
        if (this.timeLabel != null)
        {
            if (CycleMod.fixedCycle)
            {
                if (fixedCycleSlider.valueInt == 61)
                {
                    this.timeLabel.text = "UNLIMITED";
                }
                else
                {
                    this.timeLabel.text = (fixedCycleSlider.valueFloat / 2).ToString() + " MINUTES";
                }
            }
            else
            {
                this.timeLabel.text = (minCycleSlider.valueFloat / 2).ToString() + " TO " + (maxCycleSlider.valueFloat / 2).ToString() + " MINUTES";
            }
        }
        if (hunterToggle.valueBool)
        {
            cycleRect.colorFill = new Color(0f, 0.2f, 0f);
            this.presetDefault.greyedOut = false;
            this.presetEasy.greyedOut = false;
            this.presetHard.greyedOut = false;
            this.presetCure.greyedOut = false;
            this.startBox.greyedOut = false;
            this.pebblesBox.greyedOut = false;
        }
        else
        {
            cycleRect.colorFill = new Color(0.2f, 0f, 0f);
            this.presetDefault.greyedOut = true;
            this.presetEasy.greyedOut = true;
            this.presetHard.greyedOut = true;
            this.presetCure.greyedOut = true;
            this.startBox.greyedOut = true;
            this.pebblesBox.greyedOut = true;
        }
        if (lengthToggle.valueBool)
        {
            lengthRect.colorFill = new Color(0f, 0.2f, 0f);
            this.minCycleSlider.greyedOut = false;
            this.maxCycleSlider.greyedOut = false;
            this.rangeButton.greyedOut = false;
            this.fixedButton.greyedOut = false;
        }
        else
        {
            lengthRect.colorFill = new Color(0.2f, 0f, 0f);
            this.minCycleSlider.greyedOut = true;
            this.maxCycleSlider.greyedOut = true;
            this.rangeButton.greyedOut = true;
            this.fixedButton.greyedOut = true;
        }
        if (CycleMod.fixedCycle)
        {
            this.minCycleSlider.Hide();
            this.maxCycleSlider.Hide();
            this.fixedCycleSlider.Show();
            this.rangeButton.colorEdge = new Color(0.3f, 0.3f, 0.3f);
            this.fixedButton.colorEdge = new Color(0.8f, 0.8f, 0.8f);
            Vector2 rect2Pos = new Vector2(this.lengthRect.GetPos().x - 10f, this.lengthRect.GetPos().y - 5f);
            this.timeLabel.pos = rect2Pos + new Vector2(this.lengthRect.size.x / 2, this.lengthRect.size.y - 225f);
        }
        else
        {
            this.minCycleSlider.Show();
            this.maxCycleSlider.Show();
            this.fixedCycleSlider.Hide();
            this.rangeButton.colorEdge = new Color(0.8f, 0.8f, 0.8f);
            this.fixedButton.colorEdge = new Color(0.3f, 0.3f, 0.3f);
            Vector2 rect2Pos = new Vector2(this.lengthRect.GetPos().x - 10f, this.lengthRect.GetPos().y - 5f);
            this.timeLabel.pos = rect2Pos + new Vector2(this.lengthRect.size.x / 2, this.lengthRect.size.y - 245f);
        }
        this.fixedLength.valueBool = CycleMod.fixedCycle;
    }


    public override void Signal(UItrigger trigger, string signal)
    {
        base.Signal(trigger, signal);
        switch (signal)
        {
            case "default":
                this.startBox.value = "19";
                this.pebblesBox.value = "5";
                break;
            case "easy":
                this.startBox.value = "35";
                this.pebblesBox.value = "10";
                break;
            case "hard":
                this.startBox.value = "10";
                this.pebblesBox.value = "3";
                break;
            case "cure":
                this.startBox.value = "19";
                this.pebblesBox.value = "9999";
                break;
            case "range":
                CycleMod.fixedCycle = false;
                break;
            case "fixed":
                CycleMod.fixedCycle = true;
                break;
        }
    }
    public override void ConfigOnChange()
    {
        //Hunter Cycles
        if (config.ContainsKey("hunterToggle"))
        {
            if (config["hunterToggle"] == "true")
            {
                CycleMod.customHunterCycles = true;
            }
            else
            {
                CycleMod.customHunterCycles = false;
            }
        }
        if (config.ContainsKey("startCycle"))
        {
            CycleMod.startCycles = int.Parse(config["startCycle"]);
        }
        if (config.ContainsKey("pebblesCycle"))
        {
            CycleMod.pebblesCycles = int.Parse(config["pebblesCycle"]);
        }

        //Cycle Length
        if (config.ContainsKey("lengthToggle"))
        {
            if (config["lengthToggle"] == "true")
            {
                CycleMod.customCycleLength = true;
            }
            else
            {
                CycleMod.customCycleLength = false;
            }
        }
        if (config.ContainsKey("fixedCycle"))
        {
            if (config["fixedCycle"] == "true")
            {
                CycleMod.fixedCycle = true;
            }
            else
            {
                CycleMod.fixedCycle = false;
            }
        }
        if (config.ContainsKey("minLength"))
        {
            CycleMod.minimumCycleLength = (int)float.Parse(config["minLength"]) / 2 * 60;
        }
        if (config.ContainsKey("maxLength"))
        {
            CycleMod.maximumCycleLength = (int)float.Parse(config["maxLength"]) / 2 * 60;
        }
        if (config.ContainsKey("fixedLength"))
        {
            CycleMod.fixedCycleLength = (int)float.Parse(config["fixedLength"]) / 2 * 60;
        }
    }
    public override bool Configuable()
    {
        return true;
    }
}

