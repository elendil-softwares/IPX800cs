﻿// This file is part of IPX800 C#.
// Copyright (c) Julien TSCHAPPAT, All rights reserved.
// 
// IPX800 C# is free software; you can redistribute it and/or modify 
// it under the terms of the GNU Lesser General Public License as published by 
// the Free Software Foundation; either version 3.0 of the License, or 
// (at your option) any later version.
// 
// IPX800 C# is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
// Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public
// License along with IPX800 C#. If not, see <https://www.gnu.org/licenses/lgpl.html>
namespace software.elendil.IPX800.Enum
{
	/// <summary>
	/// Possibles states of an output of the IPX800
	/// </summary>
	public enum OutputState
	{
		/// <summary>
		/// Output is inactive
		/// </summary>
		Inactive = 0,
		/// <summary>
		/// Output is active
		/// </summary>
		Active = 1,
	}
}