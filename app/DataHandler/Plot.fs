namespace DataHandler

module Plot =
    open XPlot.GoogleCharts

    let line x y title=
        let plotData  = List.zip (x|> Seq.toList) (y |> Seq.toList)

        let options =
            Options
                ( title = title,
                curveType = "function",
                width = 600,
                height = 400,
                vAxis = Axis(logScale = true, format="decimal", title="w_n"),
                hAxis = Axis(logScale = true, format="scientific", title="n") )

        plotData
        |> Chart.Line
        |> Chart.WithOptions options
        |> Chart.Show