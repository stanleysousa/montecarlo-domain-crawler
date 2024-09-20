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

    ///<summary>Creates samples from a continuous uniform distribution.</summary>
    ///<param name="n">Number of samples.</param>
    ///<param name="lower">Lower value.</param>
    ///<param name="upper">Upper value.</param>
    ///<returns>Samples generated using Mersenne Twister number generator.</returns>
    let createContinuousUniformSamples n =
            let y = n |> Array.zeroCreate
            Distributions.ContinuousUniform.Samples(Random.MersenneTwister(), y, 0, 1)
            y

    ///<summary>Creates discrete samples from a uniform distribution.</summary>
    ///<param name="n">Number of samples.</param>
    ///<returns>Samples generated using Mersenne Twister number generator.</returns>
    let createDiscreteUniformSamples n coefficient=
        n
        |> createContinuousUniformSamples
        |> Seq.map(fun n -> nextInt coefficient n)
