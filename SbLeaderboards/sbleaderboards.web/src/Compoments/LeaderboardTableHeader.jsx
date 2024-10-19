/* eslint-disable react/prop-types */
import "react";
import { Button } from "react-bootstrap";

function LeaderboardTableHeader({ expType, sortKey, isDescending, isDarkMode, handleSort }) {
	const renderSortArrow = (key) => {
		// Correctly handle the sort arrow logic
		if (sortKey === key) {
			return isDescending ? "↓" : "↑"; // Down arrow when descending, up arrow when ascending
		}
		return null; // No arrow if not the current sort column
	};

	return (
		<th>
			<Button className="transition" variant={isDarkMode ? "dark" : "light"} onClick={() => handleSort(expType)}>
				{expType.charAt(0).toUpperCase() + expType.slice(1)} Exp {renderSortArrow(expType)}
			</Button>
		</th>
	);
}

export default LeaderboardTableHeader;