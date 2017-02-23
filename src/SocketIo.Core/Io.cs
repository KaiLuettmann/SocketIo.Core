﻿using SocketIo.SocketTypes;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace SocketIo
{
	/// <summary>
	/// Static class used to connect sockets
	/// </summary>
	public static class Io
	{
		private const int DefaultTimeout = 3000;

		/// <summary>
		/// Restarts the socket with the parameters provided, if null, it defaults to what is already set. If the socket has a listener setup, it will restart as well.
		/// </summary>
		/// <param name="socket"></param>
		/// <param name="ip"></param>
		/// <param name="sendPort"></param>
		/// <param name="receivePort"></param>
		/// <param name="type"></param>
		/// <param name="timeout"></param>
		/// <returns></returns>
		public static SocketIo Restart(this SocketIo socket, string ip=null, ushort? sendPort=null, ushort? receivePort=null, SocketHandlerType? type=null, int timeout = DefaultTimeout)
		{
			socket.Close();
			socket.Reset(ip, sendPort, receivePort, timeout, type);
			return socket;
		}

		/// <summary>
		/// Creates a socket that will send and receive messages
		/// </summary>
		/// <param name="ip"></param>
		/// <param name="sendPort"></param>
		/// <param name="receivePort"></param>
		/// <param name="type"></param>
		/// <param name="timeout"></param>
		/// <param name="initialEmit"></param>
		/// <returns></returns>
		public static SocketIo Create(string ip, ushort sendPort, ushort receivePort, SocketHandlerType type, int timeout = DefaultTimeout, string initialEmit = null)
		{
			SocketIo socket = SocketIo.CreateSender(ip, sendPort, timeout, type, initialEmit);
			socket.AddListener(receivePort);
			return socket;
		}

		/// <summary>
		/// Creates a socket that will send messages
		/// </summary>
		/// <param name="ip"></param>
		/// <param name="sendPort"></param>
		/// <param name="type"></param>
		/// <param name="timeout"></param>
		/// <param name="initialEmit"></param>
		/// <returns></returns>
		public static SocketIo CreateSender(string ip, ushort sendPort,SocketHandlerType type,int timeout= DefaultTimeout, string initialEmit=null)
		{
			SocketIo socket = SocketIo.CreateSender(ip, sendPort, timeout, type, initialEmit);

			return socket;
		}

		/// <summary>
		/// Adds a listener to the socket
		/// </summary>
		/// <param name="socket"></param>
		/// <param name="receivePort"></param>
		/// <returns></returns>
		public static SocketIo AddListener(this SocketIo socket,ushort receivePort)
		{
			socket.Connect(receivePort);
			return socket;
		}

		/// <summary>
		/// Adds a sender to the socket
		/// </summary>
		/// <param name="socket"></param>
		/// <param name="sendPort"></param>
		/// <param name="initialEmit"></param>
		/// <returns></returns>
		public static SocketIo AddSender(this SocketIo socket, ushort sendPort, string initialEmit = null)
		{
			socket.AddSender(sendPort, initialEmit);
			return socket;
		}
		/// <summary>
		/// Creates a socket that will receive messages
		/// </summary>
		/// <param name="ip"></param>
		/// <param name="receivePort"></param>
		/// <param name="type"></param>
		/// <param name="timeout"></param>
		/// <returns></returns>
		public static SocketIo CreateListener(string ip, ushort receivePort, SocketHandlerType type, int timeout = DefaultTimeout)
		{
			SocketIo socket = SocketIo.CreateListener(ip, receivePort, timeout, type);

			return socket;
		}


	}
}
