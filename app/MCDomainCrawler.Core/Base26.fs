namespace MCDomainCrawler.Core

module Base26=

    open System.Linq

    type Digit = { character: char; remainder: int}

    let alphabet = dict [
        ( '0', 'a' );
        ( '1', 'b' );
        ( '2', 'c' );
        ( '3', 'd' );
        ( '4', 'e' );
        ( '5', 'f' );
        ( '6', 'g' );
        ( '7', 'h' );
        ( '8', 'i' );
        ( '9', 'j' );
        ( 'A', 'k' );
        ( 'B', 'l' );
        ( 'C', 'm' );
        ( 'D', 'n' );
        ( 'E', 'o' );
        ( 'F', 'p' );
        ( 'G', 'q' );
        ( 'H', 'r' );
        ( 'I', 's' );
        ( 'J', 't' );
        ( 'K', 'u' );
        ( 'L', 'v' );
        ( 'M', 'w' );
        ( 'N', 'x' );
        ( 'O', 'y' );
        ( 'P', 'z' ); ]

    let countWords digits=
        (int)(26.0 ** digits)

    let getNumber value=
        { character = alphabet.ElementAt(value % 26).Key; remainder=value/26 }

    let getLetter value=
        { character = alphabet.ElementAt(value % 26).Value; remainder=value/26 }