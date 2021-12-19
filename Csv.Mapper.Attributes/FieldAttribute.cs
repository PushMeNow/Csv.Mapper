using System;
using Dawn;

namespace Csv.Mapper.Attributes
{
    public class FieldAttribute : Attribute
    {
        private readonly int _columnIndex;

        public FieldAttribute(int columnIndex)
        {
            Guard.Argument(_columnIndex, nameof(columnIndex))
                 .NotNegative();

            _columnIndex = columnIndex;
        }
    }
}