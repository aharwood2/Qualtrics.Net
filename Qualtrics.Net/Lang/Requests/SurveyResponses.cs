/*
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

namespace Qualtrics.Net.Lang.Requests.SurveyResponses
{
    // Create Response Request //

    public class CreateResponseRequest : Request
    {
        public Values Values { get; set; }
    }

    // This will need to be extended based on the survey structure //
    abstract public class Values
    {
        public string DistributionChannel { get; set; }

        public int Duration { get; set; }

        public string EndDate { get; set; }

        public int Finished { get; set; }

        public string LocationLatitude { get; set; }

        public string LocationLongitude { get; set; }

        public int Progress { get; set; } = 1;

        public string StartDate { get; set; }

        public string UserLanguage { get; set; }
    }

    // TODO: Add more JSON structures for remaining parts of Survey Responses API
}
