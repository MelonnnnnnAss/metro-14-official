using Content.Server.GameTicking;
using Content.Server.GameTicking.Rules;
using Content.Server._Metro14.GameRules.Components;
using Content.Shared.GameTicking.Components;

namespace Content.Server._Metro14.GameRules;

/// <summary>
/// Система управления режима захвата точек.
/// </summary>
public sealed class RadioStationRuleSystem : GameRuleSystem<RadioStationRuleComponent>
{
    [Dependency] private readonly SharedTransformSystem _transform = default!;

    public override void Initialize()
    {
        base.Initialize();
    }

    /// <summary>
    /// Поле отражающее, выбран ли в данный момент режим захвата радиостанций.
    /// Необходимо, чтобы при захвате последней радиостанции раунд закончился.
    /// </summary>
    static public bool IsEnabledRule = false;

    /// <summary>
    /// Информация о суммарном количестве точек на карте.
    /// </summary>
    static public int RadiostationSummaryCount = 0;

    /// <summary>
    /// Информация о количестве захваченных точек.
    /// </summary>
    static public int RadiostationCapturedCount = 0;

    /// <summary>
    /// Частота фракции-лидера.
    /// </summary>
    static public string RadiostationLeaderFrequency = "";

    /// <summary>
    /// Базовый метод инициализации правила в игре.
    /// </summary>
    protected override void Added(EntityUid uid, RadioStationRuleComponent comp, GameRuleComponent gameRule, GameRuleAddedEvent args)
    {
        base.Added(uid, comp, gameRule, args);

        IsEnabledRule = true;
    }

    /// <summary>
    /// Обработчик окончания раунда.
    /// </summary>
    protected override void AppendRoundEndText(EntityUid uid, RadioStationRuleComponent component, GameRuleComponent gameRule, ref RoundEndTextAppendEvent args)
    {
        base.AppendRoundEndText(uid, component, gameRule, ref args);

        args.AddLine(Loc.GetString("radiostation-summary-count", ("count", RadiostationSummaryCount)));
        args.AddLine(Loc.GetString("radiostation-captured-count", ("count", RadiostationCapturedCount)));
        args.AddLine(Loc.GetString("radiostation-leader-frequency", ("frequency", RadiostationLeaderFrequency)));
    }
}
