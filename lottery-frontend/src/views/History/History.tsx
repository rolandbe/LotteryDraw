import { useEffect, useState } from "react";
import { DataGrid, GridColDef } from '@mui/x-data-grid';
import { mergeMap } from "rxjs";
import { fromFetch } from 'rxjs/fetch';
import { HistoryData } from "../../dto/HistoryData";
import Grid from "@mui/material/Grid";

export default function History() {
    const [historyData, setHistoryData] = useState<Array<HistoryData>>([]);

    function formatDate(params) {
        return new Date(params.row.drawnAt).toLocaleString();
    }

    const columns: GridColDef[] = [
        {
            field: 'numbers',
            headerName: 'Numbers',
            sortable: true,
            flex: 1
        },
        {
            field: 'drawnAt',
            headerName: 'Drawn at',
            sortable: true,
            flex: 1,
            valueGetter: formatDate
        }
      ];
    
    useEffect(() => {
      const subscription = fromFetch('http://localhost:5000/api/lottery/gethistorydata')
        .pipe(
          mergeMap(response => response.json())
        )
        .subscribe(data => setHistoryData(data));
  
      return () => subscription.unsubscribe();
    }, []);

    return(
        <>
            <Grid item xs={12}>
                <h1>Draw History</h1>
            </Grid>
            <Grid item xs={1} md={2} ></Grid>
            <Grid item xs={10} md={8}>
                <div style={{ height: 400, width: '100%' }}>
                    <DataGrid
                        rows={historyData}
                        columns={columns}
                        hideFooter={true}
                        disableSelectionOnClick={true}
                    />
                </div>
            </Grid>
            <Grid item xs={1} md={2}></Grid>
            
        </>
    );
}