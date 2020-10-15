using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OptionalUI;
using UnityEngine;

public class CycleConfig : OptionInterface
{
    public OpRect cycleRect;
    public OpLabel title;
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
    public CycleConfig() : base(CycleMod.mod)
    {

    }

    public override void Initialize()
    {
        //Tabs
        this.Tabs = new OpTab[1];
        this.Tabs[0] = new OpTab("Config");
        this.cycleRect = new OpRect(new Vector2(50f, 300f), new Vector2(500f, 250f), 0.3f);
        //Labels
        Vector2 rectPos = new Vector2(this.cycleRect.GetPos().x - 10f, this.cycleRect.GetPos().y - 5f);
        this.title = new OpLabel(rectPos + new Vector2(this.cycleRect.size.x / 2, this.cycleRect.size.y - 25f), new Vector2(0f, 0f), "CYCLE CONFIG", FLabelAlignment.Center, true);
        this.description = new OpLabel(rectPos + new Vector2(this.cycleRect.size.x / 2, this.cycleRect.size.y - 45f), new Vector2(0f, 0f), "Adjust Hunter's starting cycles and the number of cycles given to them by Five Pebbles", FLabelAlignment.Center, false);
        this.startCycles = new OpLabel(new Vector2(rectPos.x + (this.cycleRect.size.x / 2 - 120f), rectPos.y + this.cycleRect.size.y - 80f), new Vector2(0f, 0f), "Starting Cycles", FLabelAlignment.Center, false);
        this.pebblesCycles = new OpLabel(new Vector2(rectPos.x + (this.cycleRect.size.x / 2 + 120f), rectPos.y + this.cycleRect.size.y - 80f), new Vector2(0f, 0f), "Pebbles Cycles", FLabelAlignment.Center, false);
        this.Tabs[0].AddItems(this.cycleRect, this.title, this.description, this.startCycles, this.pebblesCycles);
        //Textboxes
        this.startBox = new OpTextBox(startCycles.GetPos() + new Vector2(-30f, -25f), 80f, "startCycle", "19", OpTextBox.Accept.Int);
        this.pebblesBox = new OpTextBox(pebblesCycles.GetPos() + new Vector2(-30f, -25f), 80f, "pebblesCycle", "5", OpTextBox.Accept.Int);
        this.Tabs[0].AddItems(this.startBox, this.pebblesBox);
        //Presets
        Vector2 presetPos = new Vector2(rectPos.x + 55f, rectPos.y - 5f);
        this.presetTitle = new OpLabel(rectPos + new Vector2(this.cycleRect.size.x / 2, this.cycleRect.size.y - 150f), new Vector2(0f, 0f), "PRESETS", FLabelAlignment.Center, true);
        this.presetDescription = new OpLabel(rectPos + new Vector2(this.cycleRect.size.x / 2, this.cycleRect.size.y - 175f), new Vector2(0f, 0f), "Choose from four different presets or manually enter the number you want by\nclicking on the boxes above and entering the desired number", FLabelAlignment.Center, false);
        this.presetDefault = new OpSimpleButton(presetPos + new Vector2(30f, 30f), new Vector2(80f, 30f), "default", "DEFAULT");
        this.presetDefault.description = "Reset cycle numbers to their defaults";
        this.presetEasy = new OpSimpleButton(presetPos + new Vector2(120f, 30f), new Vector2(80f, 30f), "easy", "EASY");
        this.presetEasy.description = "Start with more cycles, and recieve more from Five Pebbles";
        this.presetHard = new OpSimpleButton(presetPos + new Vector2(210f, 30f), new Vector2(80f, 30f), "hard", "HARD");
        this.presetHard.description = "Start with less cycles, and recieve less from Five Pebbles";
        this.presetCure = new OpSimpleButton(presetPos + new Vector2(300f, 30f), new Vector2(80f, 30f), "cure", "CURE");
        this.presetCure.description = "Start with the default number of cycles, but visiting Five Pebbles will essentially cure Hunter's illness";
        //Credits
        this.credits = new OpLabel(rectPos + new Vector2(this.cycleRect.size.x / 2, -12f), new Vector2(0f, 0f), "Made by LeeMoriya", FLabelAlignment.Center, false);
        this.Tabs[0].AddItems(this.presetTitle, this.presetDescription, this.presetDefault, this.presetEasy, this.presetHard, this.presetCure, this.credits);
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
        }
    }
    public override void ConfigOnChange()
    {
        if (config.ContainsKey("startCycle") && config.ContainsKey("pebblesCycle"))
        {
            CycleMod.startCycles = int.Parse(config["startCycle"]);
            CycleMod.pebblesCycles = int.Parse(config["pebblesCycle"]);
            Debug.Log("Custom Hunter Cycles Loaded:");
            Debug.Log("Starting: [" + CycleMod.startCycles + "] | Pebbles: [" + CycleMod.pebblesCycles + "]");
        }
    }
    public override bool Configuable()
    {
        return true;
    }
}

