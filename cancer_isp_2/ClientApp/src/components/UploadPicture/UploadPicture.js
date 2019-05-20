import React from "react";
import { Card, Row, Col, Form, ListGroup, ListGroupItem } from "react-bootstrap";
import propTypes from "prop-types";
import { Link } from "react-router-dom";

function SearchCard(props) {
    SearchCard.propTypes = {
        onInputChange: propTypes.func,
        onSearchFieldChange: propTypes.func
    }

    return (
        <Card>
            <Card.Header>
                Upload Picture
            </Card.Header>
            <Card.Body>
                <Form.Group>
                    <Form.Label>Search term</Form.Label>
                    <br />
                    <Form.Control placeholder="Eg. Skeleton tree" name="searchTerm" onChange={props.onInputChange} />
                </Form.Group>
                <Form.Group>
                    <Form.Label>Search through:</Form.Label>
                    <Form.Control as="select" name="searchField" onChange={props.onSearchFieldChange}>
                        <option>Song</option>
                        <option>Artist</option>
                        <option>Album</option>
                    </Form.Control>
                </Form.Group>
            </Card.Body>
        </Card>
    );
}

function SearchResultCard({ items, searchField }) {
    SearchResultCard.propTypes = {
        items: propTypes.array,
        searchField: propTypes.string
    }

    return (
        <Card>
            <ListGroup className="list-group-flush">
                {items.map(item => (
                    <ListGroupItem key={item.id}>
                        <LinkToSearchItem name={item.name} id={item.id} searchField={searchField} />
                    </ListGroupItem>
                ))}
            </ListGroup>
        </Card>
    );
}

function LinkToSearchItem(props) {
    LinkToSearchItem.propTypes = {
        searchField: propTypes.string,
        name: propTypes.string,
        id: propTypes.number
    }

    if (props.searchField === "Song") {
        return <Link to={`/song/${props.id}`}>{props.name}</Link>;
    } else if (props.searchField === "Artist") {
        return <Link to={`/artist/${props.id}`}>{props.name}</Link>;
    } else if (props.searchField === "Album") {
        return <Link to={`/album/${props.id}`}>{props.name}</Link>;
    } else {
        return <div></div>;
    }
}

class Search extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            searchTerm: "",
            searchField: "Song",
            items: []
        };

        fetch(`api/search`,
            {
                body: JSON.stringify({ SearchTerm: this.state.searchTerm, SearchField: this.state.searchField }),
                method: "POST",
                headers: {
                    "Accept": "application/json",
                    "Content-Type": "application/json"
                }
            })
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        items: result
                    });
                });

        this.onSearchTermChange = this.onSearchTermChange.bind(this);
        this.onSearchFieldChange = this.onSearchFieldChange.bind(this);
    }

    onSearchTermChange(e) {
        e.preventDefault();
        e.persist();

        fetch(`api/search`,
            {
                body: JSON.stringify({ SearchTerm: e.target.value, SearchField: this.state.searchField }),
                method: "POST",
                headers: {
                    "Accept": "application/json",
                    "Content-Type": "application/json"
                }
            })
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        items: result,
                        searchTerm: e.target.value
                    });
                });
    }

    onSearchFieldChange(e) {
        e.preventDefault();
        e.persist();

        fetch(`api/search`,
            {
                body: JSON.stringify({ SearchTerm: this.state.searchTerm, SearchField: e.target.value }),
                method: "POST",
                headers: {
                    "Accept": "application/json",
                    "Content-Type": "application/json"
                }
            })
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        items: result,
                        searchField: e.target.value
                    });
                });
    }

    render() {
        return (
            <Row>
                <Col>
                    <Row>
                        <Col>
                            <SearchCard onInputChange={this.onSearchTermChange} onSearchFieldChange={this
                                .onSearchFieldChange} />
                        </Col>
                    </Row>

                    <Row>
                        <Col>
                            <SearchResultCard {...this.state} />
                        </Col>
                    </Row>
                </Col>
            </Row>
        );
    }
}

export default Search;