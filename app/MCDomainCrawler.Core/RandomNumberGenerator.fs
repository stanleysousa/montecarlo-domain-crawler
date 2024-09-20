namespace MCDomainCrawler.Core

module RandomNumberGenerator =

    open System
    open MathNet.Numerics

    let add1 a =
        a+1

    let nextInt (coefficient : double) (number : double) =
        coefficient*number
        |> floor
        |> int
        |> add1

    ///<summary>Fills an array with continuous uniform samples.</summary>
    ///<param name="y">array to be filled.</param>
    ///<returns>Array filled with samples generated using Mersenne Twister number generator.</returns>
    let private fillSamples y =
        Distributions.ContinuousUniform.Samples(Random.MersenneTwister(), y, 0.0, 1.0)
        y

    ///<summary>Creates samples from a continuous uniform distribution.</summary>
    ///<param name="n">Number of samples.</param>
    ///<returns>Samples generated using Mersenne Twister number generator.</returns>
    let createContinuousSamples n =
        n
        |> Array.zeroCreate
        |> fillSamples

    ///<summary>Creates discrete samples from a uniform distribution.</summary>
    ///<param name="n">Number of samples.</param>
    ///<returns>Samples generated using Mersenne Twister number generator.</returns>
    let createDiscreteSamples n coefficient=
        n
        |> createContinuousSamples
        |> Seq.map(fun n -> nextInt coefficient n)
