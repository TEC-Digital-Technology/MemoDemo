using MemoApi.Adapter.Entities;
using MemoApi.Core.Infos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC.Core.Collections;
using TEC.Core.Data;
using static MemoApi.Adapter.DataSource.Data;

namespace MemoApi.Core.Converters
{
    public class MemoConverter : ValueConverterBase<MemoData, MemoInfo>
    {
        protected override MemoData ConvertBackInternal(MemoInfo value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? null : new MemoData() 
            {
                ID = value.ID,
                Title = value.Title,
                Content = value.Content
            };
        }

        protected override MemoInfo ConvertInternal(MemoData value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? null : new MemoInfo()
            {
                ID = value.ID,
                Title = value.Title,
                Content = value.Content
            };
        }
    }
}
