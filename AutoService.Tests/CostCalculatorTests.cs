using NUnit.Framework;
using AutoService.Data.Helpers;

namespace AutoService.Tests;

[TestFixture]
public class CostCalculatorTests
{
    // ── CalcTotal ──────────────────────────────────────────────

    [Test]
    public void CalcTotal_ZeroCosts_ReturnsZero()
    {
        decimal result = CostCalculator.CalcTotal(0m, 0m);
        Assert.That(result, Is.EqualTo(0m));
    }

    [Test]
    public void CalcTotal_OnlyWorkCost_ReturnsWorkCost()
    {
        decimal result = CostCalculator.CalcTotal(1500m, 0m);
        Assert.That(result, Is.EqualTo(1500m));
    }

    [TestCase(1000, 2000, 3000)]
    [TestCase(3500, 2800, 6300)]
    [TestCase(15000, 8000, 23000)]
    public void CalcTotal_Various_CorrectSum(decimal work, decimal parts, decimal expected)
    {
        decimal result = CostCalculator.CalcTotal(work, parts);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void CalcTotal_NegativeWorkCost_ThrowsArgException()
    {
        Assert.Throws<ArgumentException>(() => CostCalculator.CalcTotal(-1m, 100m));
    }

    [Test]
    public void CalcTotal_NegativePartsCost_ThrowsArgException()
    {
        Assert.Throws<ArgumentException>(() => CostCalculator.CalcTotal(100m, -1m));
    }

    // ── CalcMasterShare ────────────────────────────────────────

    [Test]
    public void CalcMasterShare_Zero_ReturnsZero()
    {
        decimal result = CostCalculator.CalcMasterShare(0m);
        Assert.That(result, Is.EqualTo(0m));
    }

    [Test]
    public void CalcMasterShare_6300_At30Percent_Returns1890()
    {
        decimal result = CostCalculator.CalcMasterShare(6300m, 30m);
        Assert.That(result, Is.EqualTo(1890m));
    }

    [Test]
    public void CalcMasterShare_InvalidPercent_Throws()
    {
        Assert.Throws<ArgumentException>(() => CostCalculator.CalcMasterShare(1000m, 110m));
    }

    // ── NextStatus ─────────────────────────────────────────────

    [TestCase("Принят", "В работе")]
    [TestCase("В работе", "Готов")]
    [TestCase("Готов", "Выдан")]
    [TestCase("Выдан", "Выдан")]
    public void NextStatus_ValidTransitions(string current, string expected)
    {
        string result = CostCalculator.NextStatus(current);
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void NextStatus_Unknown_Throws()
    {
        Assert.Throws<ArgumentException>(() => CostCalculator.NextStatus("Неизвестный"));
    }

    // ── CanAdvance ─────────────────────────────────────────────

    [Test]
    public void CanAdvance_Vydan_ReturnsFalse()
    {
        Assert.That(CostCalculator.CanAdvance("Выдан"), Is.False);
    }

    [TestCase("Принят")]
    [TestCase("В работе")]
    [TestCase("Готов")]
    public void CanAdvance_NotFinal_ReturnsTrue(string status)
    {
        Assert.That(CostCalculator.CanAdvance(status), Is.True);
    }
}
