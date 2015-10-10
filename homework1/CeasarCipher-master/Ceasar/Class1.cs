using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ceasar
{
    public class CeasarCipher
    {
        private int offset;
        private const int Textbegin = 33;
        private const int Textend = 126;

        public CeasarCipher(int offset)
        {

            this.offset = offset;
        }

        public string Encrypt(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException();
            }
            var result = "";
            foreach (var c in text)
            {
                int code = c;
                
                if ( code !=13 && code < Textbegin-1 || code > Textend)
                {
                    throw new ArgumentOutOfRangeException();
                }
                int ofcode = code + offset;
                if (code == 32)
                {
                    ofcode = 32;

                }
                else
                {
                    if (code == 13)
                    {
                        ofcode = 13;

                    }
                    else
                    {
                        if (code + offset > Textend)
                        {

                            ofcode = Textbegin + (offset - (Textend - code)) - 1;

                        }
                    }
                }
                var offsetChar = (char) ofcode;
            
                result += offsetChar;
            }
            return result;

        }



        public string Decrypt(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException();
            }
            var result = "";
            foreach (var c in text)
            {
                int cc=c;
                if (cc != 13 && cc < Textbegin-1 || cc > Textend)
                {
                    throw new ArgumentOutOfRangeException();
                }
                int ofcode = cc - offset;
                if (cc == 32)
                {
                    ofcode = 32;

                }
                else
                {
                    if (cc == 13)
                    {
                        ofcode = 13;

                    }
                    else
                    {
                        if (cc - offset < Textbegin)
                        {

                            ofcode = Textend - offset - (cc - Textbegin) + 1;

                        }
                    }
                }
                char offsetChar = (char) ofcode;
               
                result += offsetChar;
            }
            return result;

        }
    }
}
