using System;
using System.Collections.Generic;
using System.Text;

  public static class TwoFer
  {
      public static string GetResponse(string input = null)
      {
          if(string.IsNullOrWhiteSpace(input))
          {
              return "One for you, one for me.";
          }

          return string.Format("One for {0}, one for me.", input);
      }
  }
