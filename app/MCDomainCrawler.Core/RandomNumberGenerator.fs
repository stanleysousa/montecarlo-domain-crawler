namespace MCDomainCrawler.Core

module RandomNumberGenerator =

    open System
    open MathNet.Numerics

    let createUniformSamples size=
        let numbersArray:double array = Array.zeroCreate size
        Distributions.ContinuousUniform.Samples(new Random.MersenneTwister(), numbersArray, 0.0, 1.0)
        numbersArray

    let createUniformDiscreteSamples size coefficient=
        createUniformSamples size|> Seq.map(fun number -> (int)(Math.Floor((float)coefficient*number))+1)
