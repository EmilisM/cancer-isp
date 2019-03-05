import "bootstrap/dist/css/bootstrap.css";
import "./index.css";
import React from "react";
import ReactDOM from "react-dom";
import registerServiceWorker from "./registerServiceWorker";
import { BrowserRouter } from "react-router-dom";
import NavigationBar from "./components/NavigationBar";
import Body from "./components/Body";
import { createBrowserHistory } from "history";

const rootElement = document.getElementById("root");

const history = createBrowserHistory();

function App() {
    return (
        <div>
            <NavigationBar/>
            <Body/>
        </div>
    );
}

ReactDOM.render(
    <BrowserRouter history={history}>
        <App/>
    </BrowserRouter>,
    rootElement);

registerServiceWorker();