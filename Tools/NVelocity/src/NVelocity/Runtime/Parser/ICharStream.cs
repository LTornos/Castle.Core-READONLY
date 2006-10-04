namespace NVelocity.Runtime.Parser
{
	using System;

	/// <summary> 
	/// This interface describes a character stream that maintains line and
	/// column number positions of the characters.  It also has the capability
	/// to backup the stream to some extent.  An implementation of this
	/// interface is used in the TokenManager implementation generated by
	/// JavaCCParser.
	///
	/// All the methods except backup can be implemented in any fashion. backup
	/// needs to be implemented correctly for the correct operation of the lexer.
	/// Rest of the methods are all used to get information like line number,
	/// column number and the String that constitutes a token and are not used
	/// by the lexer. Hence their implementation won't affect the generated lexer's
	/// operation.
	/// </summary>
	public interface ICharStream
	{
		int Column { get; }
		int Line { get; }
		int EndColumn { get; }
		int EndLine { get; }
		int BeginColumn { get; }
		int BeginLine { get; }

		/// <summary> Returns the next character from the selected input.  The method
		/// of selecting the input is the responsibility of the class
		/// implementing this interface.  Can throw any java.io.IOException.
		/// </summary>
		char ReadChar();

		/// <summary> Backs up the input stream by amount steps. Lexer calls this method if it
		/// had already read some characters, but could not use them to match a
		/// (longer) token. So, they will be used again as the prefix of the next
		/// token and it is the implemetation's responsibility to do this right.
		/// </summary>
		void Backup(int amount);

		/// <summary> Returns the next character that marks the beginning of the next token.
		/// All characters must remain in the buffer between two successive calls
		/// to this method to implement backup correctly.
		/// </summary>
		char BeginToken();

		/// <summary> Returns a string made up of characters from the marked token beginning
		/// to the current buffer position. Implementations have the choice of returning
		/// anything that they want to. For example, for efficiency, one might decide
		/// to just return null, which is a valid implementation.
		/// </summary>
		String GetImage();

		/// <summary> Returns an array of characters that make up the suffix of length 'len' for
		/// the currently matched token. This is used to build up the matched string
		/// for use in actions in the case of MORE. A simple and inefficient
		/// implementation of this is as follows :
		///
		/// {
		/// String t = GetImage();
		/// return t.substring(t.length() - len, t.length()).toCharArray();
		/// }
		/// </summary>
		char[] GetSuffix(int len);

		/// <summary> The lexer calls this function to indicate that it is done with the stream
		/// and hence implementations can free any resources held by this class.
		/// Again, the body of this function can be just empty and it will not
		/// affect the lexer's operation.
		/// </summary>
		void Done();
	}
}