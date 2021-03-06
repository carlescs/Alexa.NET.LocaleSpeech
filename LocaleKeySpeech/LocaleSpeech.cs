﻿using System;
using System.Threading.Tasks;
using Alexa.NET.Response;

namespace Alexa.NET.LocaleSpeech
{
    public class LocaleSpeech : ILocaleSpeech
    {
        public ILocaleSpeechStore Store { get; }
        public string Locale { get; }

        public LocaleSpeech(ILocaleSpeechStore store, string locale)
        {
            Store = store ?? throw new ArgumentNullException(nameof(store));
            Locale = locale ?? throw new ArgumentNullException(nameof(locale));
        }

        public async Task<IOutputSpeech> Get(string key, params object[] arguments)
        {
            var result = await Store.Get(Locale, key, arguments);
            if (result == null)
            {
                throw new ArgumentOutOfRangeException(nameof(key),$"No key \"{key}\" found in store");
            }

            return result;
        }
    }
}
