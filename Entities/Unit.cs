using CsvHelper.Configuration.Attributes;
using System.Text.Json.Serialization;
using w6_assignment_ksteph.Combat;
using w6_assignment_ksteph.Commands.Invokers;
using w6_assignment_ksteph.Commands.ItemCommands;
using w6_assignment_ksteph.Commands.UnitCommands;
using w6_assignment_ksteph.DataTypes;
using w6_assignment_ksteph.DataTypes.Structs;
using w6_assignment_ksteph.FileIO.Csv.Converters;
using w6_assignment_ksteph.Interfaces;
using w6_assignment_ksteph.Interfaces.CharacterBehaviors;
using w6_assignment_ksteph.Interfaces.InventoryBehaviors;
using w6_assignment_ksteph.Interfaces.ItemBehaviors;
using w6_assignment_ksteph.Inventories;
using w6_assignment_ksteph.Items;
using w6_assignment_ksteph.Items.WeaponItems;

namespace w6_assignment_ksteph.Entities;

public abstract class Unit : IEntity, ITargetable, IAttack, IHaveInventory
{
    // Unit is an abstract class that holds basic unit properties and functions.

    [Name("Name")]                                          // CsvHelper Attribute
    public virtual string Name { get; set; }

    [Name("Class")]                                         // CsvHelper Attribute
    public virtual string Class { get; set; }

    [Name("Level")]                                         // CsvHelper Attribute
    public virtual int Level { get; set; }

    [Name("HP")]                                            // CsvHelper Attribute
    [JsonPropertyName("HP")]                                // Json Atribute
    public virtual int HitPoints { get; set; }

    public virtual int MaxHitPoints { get; set; }

    [Name("Inventory")]                                     // CsvHelper Attribute
    [JsonPropertyName("Inventory")]                         // Json Atribute
    [TypeConverter(typeof(CsvInventoryConverter))]          // CsvHelper Attribute that helps CsvHelper import a new inventory object instead of a string.
    public virtual Inventory Inventory { get; set; } = new();

    [Name("Position")]                                         // CsvHelper Attribute
    [JsonPropertyName("Position")]                         // Json Atribute
    [TypeConverter(typeof(CsvPositionConverter))]          // CsvHelper Attribute that helps CsvHelper import a new Position struct instead of a string.
    public virtual Position Position { get; set; } = new();

    [Ignore] [JsonIgnore]
    public virtual CommandInvoker Invoker { get; set; } = new();

    [Ignore] [JsonIgnore]
    public virtual UseItemCommand UseItemCommand { get; set; } = null!;

    [Ignore] [JsonIgnore]
    public virtual EquipCommand EquipCommand { get; set; } = null!;

    [Ignore] [JsonIgnore]

    public virtual DropItemCommand DropItemCommand { get; set; } = null!;

    [Ignore] [JsonIgnore]
    public virtual TradeItemCommand TradeItemCommand { get; set; } = null!;

    [Ignore] [JsonIgnore]
    public virtual AttackCommand AttackCommand { get; set; } = null!;

    [Ignore] [JsonIgnore]
    public virtual MoveCommand MoveCommand { get; set; } = null!;

    [Ignore]
    [JsonIgnore]
    public UnitStats Stats { get; set; } = null!;

    public Unit()
    {
        Inventory.Unit = this;
    }

    public Unit(string name, string characterClass, int level, int hitPoints, Inventory inventory)
    {
        Name = name;
        Class = characterClass;
        Level = level;
        MaxHitPoints = hitPoints;
        Inventory = inventory;
        Inventory.Unit = this;
    }

    // Attacks the target unit.
    public virtual void Attack(IEntity target)
    {
        AttackCommand = new(this, target);
        Invoker.ExecuteCommand(AttackCommand);
    }

    // Moves the unit to a position.
    public virtual void Move()
    {
        MoveCommand = new(this);
        Invoker.ExecuteCommand(MoveCommand);
    }

    // Has the unit take damage then check if it is dead.
    public virtual void Damage(int damage)
    {
        HitPoints -= damage;
        OnHealthChanged();

        if (IsDead())
            OnDeath();
    }

    public virtual void Heal(int heal)
    {
        HitPoints += heal;
        OnHealthChanged();
    }

    // Triggers every time this unit takes damage.
    public virtual void OnHealthChanged()
    {
        if (HitPoints > MaxHitPoints)
            HitPoints = MaxHitPoints;
        if (HitPoints <= 0)
            HitPoints = 0;
    }

    // Triggers when this unit dies.
    public virtual void OnDeath()
    {
        
    }

    // Function to check to see if unit should be dead.
    public bool IsDead()
    {
        return HitPoints <= 0;
    }

    public override string ToString()
    {
        return $"{Name},{Class},{Level},{HitPoints},{Inventory}";
    }

    public string GetHealthBar()
    {
        string bar = "[[";
        for (int i = 0; i < MaxHitPoints; i++)
        {
            if (i < HitPoints)
                bar += "[green]■[/]";
            else
                bar += "[red3]■[/]";
        }
        bar += "]]";

        if (HitPoints <= 0)
        {
            return $"[dim]{bar}[/]";
        }
        return bar;
    }

    public void Equip(IWeaponItem item)
    {
        EquipCommand = new(this, item);
        Invoker.ExecuteCommand(EquipCommand);
    }

    public void DropItem(IItem item)
    {
        DropItemCommand = new(this, item);
        Invoker.ExecuteCommand(DropItemCommand);
    }

    public void TradeItem(IItem item, IEntity target)
    {
        TradeItemCommand = new(this, item, target);
        Invoker.ExecuteCommand(TradeItemCommand);
    }

    public void UseItem(IItem item)
    {
        UseItemCommand = new(item);
        Invoker.ExecuteCommand(UseItemCommand);
    }

}
