import { BrowserRouter, Route, Routes } from 'react-router-dom';
import "react";
import "./styles.css";
import CombinedProvider from "./Provider/CombinedProvider";
import Leaderboard from "./Pages/LeaderboardPage";
import Header from "./Compoments/Header";
import Playerpage from './Pages/PlayerPage';
import "bootstrap/dist/css/bootstrap.min.css";

function App() {
    return (
        <BrowserRouter basename={import.meta.env.BASE_URL}>
            <CombinedProvider>
                <Header />
                <Routes>
                    <Route path="/" element={<Leaderboard />} />
                    <Route path="/SbLeaderboards" element={<Leaderboard />} />
                    <Route path="/Player/:playerId" element={<Playerpage />} /> 
                </Routes>
            </CombinedProvider>
        </BrowserRouter>
    );
}

export default App;