using Util.Core.DataAnnotationsTemplates;

namespace Util.Core
{
    public enum Operator
    {
        [DescriptionLocalized(typeof(Util.Resources.Operator), nameof(Util.Resources.Operator.Equal))]
        Equal,

        [DescriptionLocalized(typeof(Util.Resources.Operator), nameof(Util.Resources.Operator.NotEqual))]
        NotEqual,

        [DescriptionLocalized(typeof(Util.Resources.Operator), nameof(Util.Resources.Operator.GreaterThan))]
        GreaterThan,

        [DescriptionLocalized(typeof(Util.Resources.Operator), nameof(Util.Resources.Operator.LessThan))]
        Less,

        [DescriptionLocalized(typeof(Util.Resources.Operator), nameof(Util.Resources.Operator.GreaterThanOrEqual))]
        GreaterThanEqual,

        [DescriptionLocalized(typeof(Util.Resources.Operator), nameof(Util.Resources.Operator.LessThanOrEqual))]
        LessEqual,

        [DescriptionLocalized(typeof(Util.Resources.Operator), nameof(Util.Resources.Operator.Contains))]
        Contains,

        [DescriptionLocalized(typeof(Util.Resources.Operator), nameof(Util.Resources.Operator.StartsWith))]
        StartsWith,

        [DescriptionLocalized(typeof(Util.Resources.Operator), nameof(Util.Resources.Operator.EndsWith))]
        EndsWith
    }
}