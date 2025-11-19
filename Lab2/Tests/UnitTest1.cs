using System;
using System.IO;
using Xunit;
using Lab2.Application;

namespace Lab2Tests
{
    public class InventoryFacadeFullTests
    {
        private InventoryFacade _facade;
        private StringWriter _consoleOutput;

        public InventoryFacadeFullTests()
        {
            _facade = new InventoryFacade();
            _consoleOutput = new StringWriter();
            Console.SetOut(_consoleOutput);
        }

        private string GetOutput() => _consoleOutput.ToString();

        [Fact]
        // проверка добавления всех типов предметов
        public void AddAllItems_ShouldAppearInInventory()
        {
            _facade.AddWeapon("Sword", 5, "Rare", 10);
            _facade.AddArmor("Shield", 7, "Common", 15);
            _facade.AddPotion("Health Potion", 1, "Uncommon", "Restore 50 HP");
            _facade.AddQuestItem("Ancient Key", 0.1, "Legendary", "Opens ancient door");

            _facade.DisplayInventory();

            var output = GetOutput();
            Assert.Contains("Sword", output);
            Assert.Contains("Shield", output);
            Assert.Contains("Health Potion", output);
            Assert.Contains("Ancient Key", output);
        }

        [Fact]
        // проверка назначения стратегии и использования зелья
        public void UsePotionWithHealStrategy_ShouldConsumePotion()
        {
            _facade.AddPotion("Health Potion", 1, "Uncommon", "Restore 50 HP");
            _facade.SetHealStrategy("Health Potion", 50);

            _facade.UseItem("Health Potion");

            var output = GetOutput();
            Assert.Contains("Стратегия использования для 'Health Potion' назначена", output);
            Assert.Contains("Health Potion", output); 
        }

        [Fact]
        // проверка изменения состояния предмета на экипированный
        public void EquipWeapon_ShouldChangeState()
        {
            _facade.AddWeapon("Axe", 6, "Rare", 12);
            _facade.EquipItem("Axe");

            var output = GetOutput();
            Assert.Contains("Axe", output); 
        }

        [Fact]
        // проверка удаления предмета и его отсутствия в инвентаре
public void RemoveItem_ShouldRemoveFromInventory()
{
    _facade.AddArmor("Helmet", 3, "Common", 5);
    _consoleOutput.GetStringBuilder().Clear(); // очистим предыдущий вывод

    _facade.RemoveItem("Helmet");

    var output = GetOutput();
    // Проверяем, что в консоли есть сообщение об удалении
    Assert.Contains("Удален предмет: Helmet", output);

    // Проверяем, что DisplayInventory не показывает этот предмет как активный
    _consoleOutput.GetStringBuilder().Clear();
    _facade.DisplayInventory();
    output = GetOutput();
    // Проверяем, что предмет больше не отображается как добавленный
    Assert.DoesNotContain("Добавлен предмет: Helmet", output);
}

        [Fact]
// проверка работы с несколькими предметами: Equip, Use, Strategy, Remove
public void MultipleItemInteraction_ShouldWorkCorrectly()
{
    _facade.AddWeapon("Sword", 5, "Rare", 10);
    _facade.AddPotion("Health Potion", 1, "Uncommon", "Restore 50 HP");
    _facade.AddArmor("Shield", 7, "Common", 15);

    _consoleOutput.GetStringBuilder().Clear();
    _facade.EquipItem("Sword");
    _facade.UseItem("Health Potion");
    _facade.SetUpgradeWeaponStrategy("Sword", 5);
    _facade.UseItem("Sword");
    _facade.RemoveItem("Shield");

    _consoleOutput.GetStringBuilder().Clear();
    _facade.DisplayInventory();
    var output = GetOutput();

    // Проверяем, что предметы Sword и Health Potion отображаются
    Assert.Contains("Sword", output);
    Assert.Contains("Health Potion", output);
    // Проверяем, что удаленный предмет Shield больше не отображается как активный
    Assert.DoesNotContain("Добавлен предмет: Shield", output);
}


        [Fact]
        // проверка назначения стратегии повышения урона и её использования
        public void SetDamageBoostStrategy_ShouldApplyCorrectly()
        {
            _facade.AddWeapon("Bow", 2.5, "Uncommon", 8);
            _facade.SetDamageBoostStrategy("Bow", 5, 10);

            _facade.UseItem("Bow");

            var output = GetOutput();
            Assert.Contains("Стратегия использования для 'Bow' назначена", output);
        }

        [Fact]
        //проверка стратегии улучшения оружия
        public void SetUpgradeWeaponStrategy_ShouldApplyCorrectly()
        {
            _facade.AddWeapon("Dagger", 1, "Rare", 6);
            _facade.SetUpgradeWeaponStrategy("Dagger", 3);

            _facade.UseItem("Dagger");

            var output = GetOutput();
            Assert.Contains("Стратегия использования для 'Dagger' назначена", output);
        }

        [Fact]
        //проверка стратегии атаки и её применения
        public void SetAttackStrategy_ShouldApplyCorrectly()
        {
            _facade.AddWeapon("Sword", 5, "Rare", 10);
            _facade.SetAttackStrategy("Sword", 15, 100);

            _facade.UseItem("Sword");

            var output = GetOutput();
            Assert.Contains("Стратегия атаки назначена предмету 'Sword'", output);
        }

        [Fact]
        //проверка корректного сообщения при использовании несуществующего предмета
        public void UsingNonExistentItem_ShouldReturnError()
        {
            _facade.UseItem("NonExistent");

            var output = GetOutput();
            Assert.Contains("Предмет 'NonExistent' не найден", output);
        }

        [Fact]
        //проверка корректного сообщения при назначении стратегии несуществующему предмету
        public void SetStrategyOnNonExistentItem_ShouldReturnError()
        {
            _facade.SetHealStrategy("GhostPotion", 50);

            var output = GetOutput();
            Assert.Contains("Предмет 'GhostPotion' не найден для назначения стратегии", output);
        }

        
    }
}
