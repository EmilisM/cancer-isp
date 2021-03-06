import "bootstrap/dist/css/bootstrap.css";
import "./index.css";
import React from "react";
import ReactDOM from "react-dom";
import registerServiceWorker from "./registerServiceWorker";
import { BrowserRouter } from "react-router-dom";
import NavigationBar from "./components/NavigationBar";
import Body from "./components/Body";
import * as Redux from "redux";
import { Provider } from "react-redux";

const rootElement = document.getElementById("root");

function reducer(state = { loggedIn: false }, action) {
    switch (action.type) {
    case "LOGIN_SUCCESS":
        return Object.assign({}, state, { loggedIn: true });
    case "LOGOUT_SUCCESS":
        return Object.assign({}, state, { loggedIn: false });
    default:
        return state;
    }
}

const store = Redux.createStore(reducer, window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__());

function App() {
    return (
        <div>
            <NavigationBar/>
            <Body/>
        </div>
    );
}

ReactDOM.render(
    <Provider store={store}>
        <BrowserRouter>
            <App/>
        </BrowserRouter>
    </Provider>,
    rootElement);

registerServiceWorker();