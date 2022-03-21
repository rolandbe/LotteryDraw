import Button from "@mui/material/Button";
import Grid from "@mui/material/Grid";
import { useEffect, useState } from "react";
import { fromEvent } from "rxjs";

export default function Simulator(){
    const [numbers, setNumbers] = useState<string>('');
    const [firstPlay, setFirstPlay] = useState<boolean>(true);
    
    useEffect(() => {
        const start$ = fromEvent(document.getElementById('btnPlay'), 'click')
            .subscribe( click => {
                let draw = simulateDraw();

                fetch('http://localhost:5000/api/lottery/savedraw', {
                    method: 'POST',
                    body: JSON.stringify(draw),
                    headers: {'Content-Type': 'application/json; charset=UTF-8'} });

                setNumbers(draw);
                setFirstPlay(false);
        })

        return () => {
            start$.unsubscribe()
        }
    }, [])

    const simulateDraw = () => {
        let drawnNumbers =[];
        
        while(drawnNumbers.length < 5){
            let draw = getRandomInt(1,50);
            if(drawnNumbers.indexOf(draw) === -1){
                drawnNumbers.push(draw);
            }
        }
    
        return drawnNumbers.join(', ');
    }

    return(
        <>
            {/* h1 */}
            <Grid item xs={12}>
                <h1>Lottery Draw Simulator</h1>
            </Grid>
            
            {/* first row */}
            <Grid item xs={1} md={2} ></Grid>
            <Grid item xs={10} md={8}>
                <h2>{numbers}</h2>
            </Grid>
            <Grid item xs={1} md={2}></Grid>

            {/* second row */}
            <Grid item xs={12} >
                <Button id="btnPlay" variant="contained">{firstPlay ? 'Play' : 'Play Again'}</Button>
            </Grid>
        </>
    );
}

function getRandomInt(min, max) {
    min = Math.ceil(min);
    max = Math.floor(max);
    return Math.floor(Math.random() * (max - min + 1)) + min;
}