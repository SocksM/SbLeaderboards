import "react";
import "./styles.css"; // Import your styles
import CombinedProvider from "./CombinedProvider"; // Import the combined provider
import Leaderboard from "./Leaderboard";
import Header from "./Header";
import "bootstrap/dist/css/bootstrap.min.css"; // Make sure Bootstrap is imported

function App() {
    return (
        <CombinedProvider>
            <Header />
            <Leaderboard />
        </CombinedProvider>
    );
}

export default App;