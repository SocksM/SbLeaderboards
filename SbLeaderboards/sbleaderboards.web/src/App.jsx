import "react";
import "./styles.css";
import CombinedProvider from "./CombinedProvider";
import Leaderboard from "./Leaderboard";
import Header from "./Header";
import PlayerProfile from "./PlayerProfile"; // Import the player profile page component
import { BrowserRouter as Router, Route, Routes } from "react-router-dom"; // Import Router

function App() {
    return (
        <CombinedProvider>
            <Router>
                <Header />
                <Routes>
                    <Route path="/" element={<Leaderboard />} />
                    <Route path="/Player/:playerId" element={<PlayerProfile />} /> {/* Dynamic route */}
                </Routes>
            </Router>
        </CombinedProvider>
    );
}

export default App;