using MemoApi.Adapter.Entities;
using MemoApi.Core.Infos;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TEC.Core.Data;

namespace MemoApi.Core.Converters
{
    public class MessageConverter : ValueConverterBase<MessageEntity, MessageInfo>
    {
        protected override MessageEntity ConvertBackInternal(MessageInfo value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? null : new MessageEntity()
            {
                CountryCode = value.CountryCode,
                Message = value.Message,
                MessageCode = value.MessageCode
            };
        }

        protected override MessageInfo ConvertInternal(MessageEntity value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null ? null : new MessageInfo()
            {
                CountryCode = value.CountryCode,
                Message = value.Message,
                MessageCode = value.MessageCode
            };
        }
    }
}
