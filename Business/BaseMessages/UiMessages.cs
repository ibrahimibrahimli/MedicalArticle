﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BaseMessages
{
    public class UiMessages
    {
        public static string SuccessAddedMessage(string propName)
        {
            return $"{propName} uğurla əlavə olundu";
        }
        public static string SuccessUpdatedMessage(string propName)
        {
            return $"{propName} uğurla yeniləndi";
        }
        public static string SuccessDeletedMessage(string propName)
        {
            return $"{propName} uğurla sistemdən silindi";
        }
        public static string SuccessCopyTrashMessage(string propName)
        {
            return $"{propName} zibil qutusuna köçürüldü";
        }
    }
}
