﻿using System.Collections.Generic;

using SchoolSystem.Framework.Core.Contracts;
using SchoolSystem.Framework.Core.Repositories;

namespace SchoolSystem.Framework.Core.Commands.Contracts
{
    /// <summary>
    /// Represents a command that can be loaded by the parser.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Executes the command with the passed parameters.
        /// </summary>
        /// <param name="parameters">Parameters to execute the command with.</param>
        /// <param name="data"></param>
        /// <returns>Returns execution result message.</returns>
        string Execute(IList<string> parameters, ISchoolSystemData data);
    }
}