namespace Canopy2048

open canopy
open runner

module Interactions =

    let lost () =
        match someElement ".game-message.game-over" with
        | None -> false
        | Some(_) -> true

    let won () =
        match someElement ".game-message.game-won" with
        | None -> false
        | Some(_) -> true

    let state () = 
        elements ".tile"
        |> List.map(fun tile ->
            let classes = tile.GetAttribute("class").Split(' ')
            let pointClass = classes |> Array.find(fun classs -> classs.StartsWith("tile-") && not (classs.StartsWith("tile-position-")))
            let point = pointClass.Split('-').[1] |> int
            let rowColumnClass = classes |> Array.find(fun classs -> classs.StartsWith("tile-position-"))
            let column = rowColumnClass.Split('-').[2] |> int
            let row = rowColumnClass.Split([|'-'|]).[3] |> int
            { Row = row; Col = column }, point )
        // removing the duplicates due to merges:
        // group cell by identical row, col
        // and keep the one with largest value,
        // hacky but works...
        |> Seq.groupBy (fun (pos,value) -> pos.Row, pos.Col)
        |> Seq.map (fun ((row,col),cells) -> 
            cells |> Seq.maxBy (fun (pos,value) -> value))
        |> Map.ofSeq