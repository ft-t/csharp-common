using System;

namespace Ft.Common.Helpers
{
    public static class ExceptionHelper
    {
        public static string BuildMessage(Exception ex) 
        { 
            var str = ex.Message; 
 
            if (ex.InnerException != null && !string.IsNullOrEmpty(ex.InnerException.Message)) 
                return $"{str} || {BuildMessage(ex.InnerException)}"; 
 
            return str; 
        } 
    }
}