namespace AutoService.Data.Helpers;

public static class CostCalculator
{
    /// <summary>Итоговая стоимость заказа = работы + запчасти</summary>
    public static decimal CalcTotal(decimal workCost, decimal partsCost)
    {
        if (workCost < 0)  throw new ArgumentException("Стоимость работ не может быть отрицательной");
        if (partsCost < 0) throw new ArgumentException("Стоимость запчастей не может быть отрицательной");
        return workCost + partsCost;
    }

    /// <summary>Доля мастера от выручки (по умолчанию 30%)</summary>
    public static decimal CalcMasterShare(decimal totalCost, decimal percent = 30m)
    {
        if (percent < 0 || percent > 100)
            throw new ArgumentException("Процент должен быть от 0 до 100");
        return Math.Round(totalCost * percent / 100m, 2);
    }

    /// <summary>Следующий статус заказа</summary>
    public static string NextStatus(string current) => current switch
    {
        "Принят"   => "В работе",
        "В работе" => "Готов",
        "Готов"    => "Выдан",
        "Выдан"    => "Выдан",
        _ => throw new ArgumentException($"Неизвестный статус: {current}")
    };

    /// <summary>Можно ли сменить статус дальше</summary>
    public static bool CanAdvance(string current) => current != "Выдан";
}
