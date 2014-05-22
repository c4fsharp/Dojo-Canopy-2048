namespace Canopy2048

type Move = Up | Down | Left | Right

type Pos = { Row:int; Col:int; }

type Value = int

type State = Map<Pos,Value>