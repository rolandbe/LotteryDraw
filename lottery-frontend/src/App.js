import { Routes, Route, Link } from "react-router-dom";
import Grid from '@mui/material/Grid';
import './App.css';
import Home from './views/Home/Home.tsx';
import Simulator from './views/Simulator/Simulator.tsx';
import History from './views/History/History.tsx';
import NavBar from './views/NavBar/NavBar.tsx';

function App() {
  return (
    <>
      <NavBar />
      
      <div className="App">
      <Grid container spacing={2}>
        <Routes>
          <Route path="/" element={<Home />} />
          <Route path="/simulator" element={<Simulator />} />
          <Route path="/history" element={<History />} />
        </Routes>
        </Grid>
      </div>
      
      
    </>
  );
}

export default App;
