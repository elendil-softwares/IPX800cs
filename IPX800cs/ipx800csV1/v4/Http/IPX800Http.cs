﻿using System;
using System.Text;
using software.elendil.IPX800.ipx800csV1.CommandSenders;
using software.elendil.IPX800.ipx800csV1.Enum;
using software.elendil.IPX800.ipx800csV1.Exceptions;

namespace software.elendil.IPX800.ipx800csV1.v4.Http
{
	/// <summary>
	/// IPX800 v4 HTTP implementation
	/// </summary>
	public class IPX800Http : IIPX800v4
	{
		private readonly ICommandSender commandSender;

		#region Constructors

		/// <summary>
		/// Initializes a new instance of the <see cref="IPX800Http"/> class.
		/// </summary>
		/// <param name="ip">IP of the IPX800</param>
		/// <param name="port">HTTP port of the IPX800</param>
		/// <param name="pass">Password</param>
		/// <exception cref="System.ArgumentNullException">ip</exception>
		public IPX800Http(string ip, ushort port, string pass)
		{
			if (ip == null) throw new ArgumentNullException(nameof(ip));
			commandSender = new CommandSenderHttpIPX800V4(ip, port, pass);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="IPX800Http"/> class.
		/// </summary>
		/// <param name="ip">IP of the IPX800</param>
		/// <param name="port">HTTP port of the IPX800</param>
		/// <exception cref="System.ArgumentNullException">ip</exception>
		public IPX800Http(string ip, ushort port)
		{
			if (ip == null) throw new ArgumentNullException(nameof(ip));
			commandSender = new CommandSenderHttpIPX800V4(ip, port);
		}

		#endregion

		#region Build command methods

		/// <summary>
		/// Builds a command string allowing to set an output state
		/// </summary>
		/// <param name="outputNumber">The output number.</param>
		/// <param name="state">The wanted state.</param>
		/// <param name="isVirtual">Tells if the command is for a virtual output</param>
		/// <returns>The command string</returns>
		private string BuildSetOutCommandString(uint outputNumber, OutputState state, bool isVirtual)
		{
			var command = new StringBuilder();
			var outputType = isVirtual ? "VO" : "R";
			

			switch (state)
			{
				case OutputState.Active:
					command = new StringBuilder($"Set{outputType}=");
					break;

				case OutputState.Inactive:
					command = new StringBuilder($"Clear{outputType}=");
					break;
			}

			command.Append(outputNumber.ToString("D2"));

			return command.ToString();
		}

		#endregion

		#region IIPX800 implementation

		/// <summary>
		/// Gets the state of an input
		/// </summary>
		/// <param name="inputNumber">The input number.</param>
		/// <returns>The input state.</returns>
		/// <exception cref="IPX800Exception">Thrown if it was unable to  get a response</exception>
		/// <exception cref="IPX800ExecuteException">Thrown if it was unable to send the request or in case of timeout while waiting for response</exception>
		/// <exception cref="IPX800ConnectionException">Thrown if the connexion with the IPX800 failed</exception>
		public InputState GetIn(uint inputNumber)
		{
			var command = "Get=D";

			try
			{
				var jsonString = (string)commandSender.ExecuteCommand(command);
				var state = JsonResponseParser.ParseGetInResponse(jsonString, inputNumber);
				return state;
			}
			catch (IPX800ConnectionException)
			{
				throw;
			}
			catch (IPX800ExecuteException)
			{
				throw;
			}
			catch (Exception e)
			{
				throw new IPX800Exception("Unable to get a response for command '" + command + "'", e);
			}
		}

		/// <summary>
		/// Gets the state of an output
		/// </summary>
		/// <param name="outputNumber">The output number.</param>
		/// <returns>The output state.</returns>
		/// <exception cref="IPX800Exception">Thrown if it was unable to  get a response</exception>
		/// <exception cref="IPX800ExecuteException">Thrown if it was unable to send the request or in case of timeout while waiting for response</exception>
		/// <exception cref="IPX800ConnectionException">Thrown if the connexion with the IPX800 failed</exception>
		public OutputState GetOut(uint outputNumber)
		{
			var command = "Get=R";

			try
			{
				var jsonString = (string)commandSender.ExecuteCommand(command);
				var state = JsonResponseParser.ParseGetOutResponse(jsonString, outputNumber);

				return state;
			}
			catch (IPX800ConnectionException)
			{
				throw;
			}
			catch (IPX800ExecuteException)
			{
				throw;
			}
			catch (Exception e)
			{
				throw new IPX800Exception("Unable to get a response for command '" + command + "'", e);
			}
		}

		/// <summary>
		/// Sets the state of an output.
		/// </summary>
		/// <param name="outputNumber">The output number.</param>
		/// <param name="state">The state.</param>
		/// <param name="fugitive">if set to <c>true</c>, the 'fugitive' mode will be used.</param>
		/// <returns><c>true</c> if successful, <c>false</c> otherwise.</returns>
		/// <exception cref="IPX800Exception">Thrown if it was unable to  get a response</exception>
		/// <exception cref="IPX800ExecuteException">Thrown if it was unable to send the request or in case of timeout while waiting for response</exception>
		/// <exception cref="IPX800ConnectionException">Thrown if the connexion with the IPX800 failed</exception>
		public string SetOut(uint outputNumber, OutputState state, bool fugitive)
		{
			var command = "";
			var jsonResponse = "";

			try
			{
				command = BuildSetOutCommandString(outputNumber, state, false);
				jsonResponse = (string)commandSender.ExecuteCommand(command);
#if DEBUG
				Console.WriteLine("SetOut response : " + jsonResponse);
#endif
                var result = JsonResponseParser.ParseSetOutResponse(jsonResponse);
                return result;
			}
			catch (IPX800ConnectionException)
			{
				throw;
			}
			catch (IPX800ExecuteException)
			{
				throw;
			}
			catch (Exception e)
			{
				throw new IPX800Exception("Unable to get a response '" + jsonResponse + "' for command '" + command + "'", e);
			}
		}

		/// <summary>
		/// Gets the value of an analog input
		/// </summary>
		/// <param name="inputNumber">The input number.</param>
		/// <returns>The value</returns>
		/// <exception cref="IPX800Exception">Thrown if it was unable to  get a response</exception>
		/// <exception cref="IPX800ExecuteException">Thrown if it was unable to send the request or in case of timeout while waiting for response</exception>
		/// <exception cref="IPX800ConnectionException">Thrown if the connexion with the IPX800 failed</exception>
		public string GetAn(uint inputNumber)
		{
			var command = "Get=A";

			try
			{
				var jsonString = (string)commandSender.ExecuteCommand(command);
				var state = JsonResponseParser.ParseGetAnResponse(jsonString, inputNumber);

				return state;
			}
			catch (IPX800ConnectionException)
			{
				throw;
			}
			catch (IPX800ExecuteException)
			{
				throw;
			}
			catch (Exception e)
			{
				throw new IPX800Exception("Unable to get a response for command '" + command + "'", e);
			}
		}

		#endregion

		#region IIPX800V4 implementation
		
		public InputState GetVirtualIn(uint inputNumber)
		{
			var command = "Get=VI";

			try
			{
				var jsonString = (string)commandSender.ExecuteCommand(command);
				var state = JsonResponseParser.ParseGetVirtualInResponse(jsonString, inputNumber);
				return state;
			}
			catch (IPX800ConnectionException)
			{
				throw;
			}
			catch (IPX800ExecuteException)
			{
				throw;
			}
			catch (Exception e)
			{
				throw new IPX800Exception("Unable to get a response for command '" + command + "'", e);
			}
		}

		public OutputState GetVirtualOut(uint outputNumber)
		{
			var command = "Get=VO";

			try
			{
				var jsonString = (string)commandSender.ExecuteCommand(command);
				var state = JsonResponseParser.ParseGetVirtualOutResponse(jsonString, outputNumber);

				return state;
			}
			catch (IPX800ConnectionException)
			{
				throw;
			}
			catch (IPX800ExecuteException)
			{
				throw;
			}
			catch (Exception e)
			{
				throw new IPX800Exception("Unable to get a response for command '" + command + "'", e);
			}
		}

		public string SetVirtualOut(uint outputNumber, OutputState state, bool fugitive)
		{
			var command = "";
			var jsonResponse = "";

			try
			{
				command = BuildSetOutCommandString(outputNumber, state, true);
				jsonResponse = (string)commandSender.ExecuteCommand(command);
#if DEBUG
				Console.WriteLine("SetVirtualOut response : " + jsonResponse);
#endif
				var result = JsonResponseParser.ParseSetOutResponse(jsonResponse);
				return result;
			}
			catch (IPX800ConnectionException)
			{
				throw;
			}
			catch (IPX800ExecuteException)
			{
				throw;
			}
			catch (Exception e)
			{
				throw new IPX800Exception("Unable to get a response '" + jsonResponse + "' for command '" + command + "'", e);
			}
		}

		public string GetVirtualAn(uint inputNumber)
		{
			var command = "Get=VA";

			try
			{
				var jsonString = (string)commandSender.ExecuteCommand(command);
				var state = JsonResponseParser.ParseGetVirtualAnResponse(jsonString, inputNumber);

				return state;
			}
			catch (IPX800ConnectionException)
			{
				throw;
			}
			catch (IPX800ExecuteException)
			{
				throw;
			}
			catch (Exception e)
			{
				throw new IPX800Exception("Unable to get a response for command '" + command + "'", e);
			}
		}
		
		#endregion
	}
}