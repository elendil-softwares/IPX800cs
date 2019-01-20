﻿using System.Text;
using software.elendil.IPX800.IO;

namespace software.elendil.IPX800.Commands.Builders.v4.M2M
{
    public class SetOutCommandBuilder : ISetCommandBuilder
    {
        public string BuildCommandString(IPX800Output output)
        {
            StringBuilder command = null;

            switch (output.State)
            {
                case OutputState.Active:
                    command = new StringBuilder(IPX800v4CommandStrings.SetOutputActive);
                    break;

                case OutputState.Inactive:
                    command = new StringBuilder(IPX800v4CommandStrings.SetOutputInactive);
                    break;
            }

            command.Append(output.Number.ToString("D2"));

            return command.ToString();
        }
    }
}