﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dBASE.NET
{
	public abstract class DbfHeader
	{
		public DbfVersion Version { get; set; }
		public DateTime LastUpdate { get; set;  }
		public uint NumRecords { get; set; }
		public ushort HeaderLength { get; set; }
		public ushort RecordLength { get; set; }

		public static DbfHeader CreateHeader(DbfVersion version)
		{
			switch(version)
			{
				case DbfVersion.FoxBaseDBase3NoMemo:
					return new Dbf4Header();
				default:
					throw new Exception("Unsupported header version.");
			}

		}

		/// <summary>
		/// Read the .dbf file header. 
		/// </summary>
		/// <param name="reader"></param>
		public abstract void Read(BinaryReader reader);
	}
}