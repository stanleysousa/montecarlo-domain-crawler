namespace DataHandler

module NumberGenerator =
    open System
    open MathNet.Numerics

    let g z absX =
        (int)(Math.Floor((float)z*absX))+1

    let G n absX=

        //Generate n samples
        let Z:double array = Array.zeroCreate n
        Distributions.ContinuousUniform.Samples(new Random.MersenneTwister(), Z, 0.0, 1.0);

        //Convert the gerenated numebers into a word index
        Z |> Seq.map(fun z -> g z absX);