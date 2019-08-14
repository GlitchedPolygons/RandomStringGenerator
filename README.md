[![API Docs](https://img.shields.io/badge/api-docs-informational)](https://glitchedpolygons.github.io/RandomStringGenerator/api/GlitchedPolygons.Utilities.RandomStringGenerator.html)
[![License Shield](https://img.shields.io/badge/license-Apache--2.0-brightgreen)](https://github.com/GlitchedPolygons/RandomStringGenerator/blob/master/LICENSE)
[![AppVeyor](https://ci.appveyor.com/api/projects/status/xeea0e1p8i6ujqae/branch/master?svg=true)](https://ci.appveyor.com/project/GlitchedPolygons/randomstringgenerator/branch/master) [![Travis](https://travis-ci.org/GlitchedPolygons/RandomStringGenerator.svg?branch=master)](https://travis-ci.org/GlitchedPolygons/RandomStringGenerator) [![CircleCI](https://circleci.com/gh/GlitchedPolygons/RandomStringGenerator.svg?style=shield)](https://circleci.com/gh/GlitchedPolygons/RandomStringGenerator) 

# netstandard2.0 class library
## Generate random strings in C#

Use `RandomStringGenerator.GenerateRandomString()` to generate a random string. There are overloads for custom generated string length and legal characters to use for string generation. Internally uses the `System.Security.Cryptography.RNGCryptoServiceProvider` as a randomness provider.
