//@Author Fabio Cogliati

using System.Diagnostics;

namespace Cards_Generator
{
    /// <summary>
    /// Name class that contains the hash of the desired string. It keeps the source string only in debug builds
    /// </summary>
    [DebuggerDisplay("{_infoString}")]
    public class Name
    {

        /// <summary> Empty name </summary>
        public static Name NAME_NONE = new Name();


        /// <summary>
        /// Implicit conversion from string to Name
        /// </summary>
        /// <param name="str"></param>
        public static implicit operator Name(string str)
        {
            return new Name(str);
        }
#if DEBUG
        /// <summary>
        /// Implicit conversion from name to string
        /// </summary>
        /// <param name="name"></param>
        public static implicit operator string(Name name)
        {
            return name.GetString();
        }
#endif
        /// <summary>
        /// == operator
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool operator ==(Name first, Name second)
        {
            if (object.ReferenceEquals(first, null))
            {
                return object.ReferenceEquals(second, null);
            }
            else
            {
                return first.Equals(second);
            }
        }

        /// <summary>
        /// != operator
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        public static bool operator !=(Name first, Name second)
        {
            return !(first == second);
        }

     
        /// <summary>
        /// Static constructor
        /// </summary>
        static Name()
        {
            HashNone = string.Empty.GetHashCode();
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Name()
        {
            _hash = HashNone;
#if DEBUG
            _string = string.Empty;
#endif
        }

        /// <summary>
        /// String constructor
        /// </summary>
        /// <param name="name"></param>
        public Name(string name)
        {
            Set(name);
        }

        /// <summary>
        /// Equals operator
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var item = obj as Name;

            if (item != null)
            {
                return this._hash.Equals(item._hash);
            }

            return false;
        }

        /// <summary>
        /// Get name hash
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _hash;
        }

        /// <summary>
        /// Returns information about the name. Useful for debug purposes only
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return _infoString;
        }

        /// <summary>
        /// Set name by string
        /// </summary>
        /// <param name="name"></param>
        public void Set(string name)
        {
            _hash = name.GetHashCode();
#if DEBUG
            _string = name;
#endif
        }
#if DEBUG
        /// <summary>
        /// Get string version of the name, only for debug purposes
        /// </summary>
        /// <returns></returns>
        public string GetString()
        {
            return _string; 
        }
#endif

        /// <summary> Empty name hash </summary>
        private static int HashNone;


        /// <summary> Current name hash </summary>
        private int _hash;
#if DEBUG
        /// <summary> Current name string </summary>
        private string _string;
#endif
        [DebuggerBrowsable(DebuggerBrowsableState.Never)]
        private string _infoString
        {
            get
            {
#if DEBUG
                return "{ NAME : " + _string + " | " + _hash.ToString() + " }";
#else
                return "{ NAME : " + _hash.ToString() + " }";
#endif
            }
        }

    }

    
}
