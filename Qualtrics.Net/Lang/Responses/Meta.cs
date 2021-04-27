﻿/*
 * Copyright (C) 2021 Adrian Harwood
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <https://www.gnu.org/licenses/>.
 */

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Qualtrics.Net.Lang.Responses.Meta
{
    // Meta with error
    public class MetaWithError
    {
        public string HttpStatus { get; internal set; }

        public string RequestId { get; internal set; }

        public string Notice { get; internal set; }

        public Error Error { get; internal set; }
    }

    // Error
    public class Error
    {
        public string ErrorMessage { get; internal set; }

        public string ErrorCode { get; internal set; }
    }
}
