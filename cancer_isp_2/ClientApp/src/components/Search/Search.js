import React from "react";
import { Card, Row, Col, Form, ListGroup, ListGroupItem, Button } from "react-bootstrap";

function SearchCard() {
    return (
        <Card>
            <Card.Header>
                Search
            </Card.Header>
            <Card.Body>
                <Form.Group>
                    <Form.Label>Search term</Form.Label>
                    <br/>
                    <Form.Control placeholder="Eg. Skeleton tree"/>
                </Form.Group>
                <Form.Group>
                    <Form.Label>Search through:</Form.Label>
                    <Form.Control as="select">
                        <option>Song</option>
                        <option>Artist</option>
                        <option>Album</option>
                    </Form.Control>
                </Form.Group>
                <Form.Group>
                    <Button>
                        Search
                    </Button>
                </Form.Group>
            </Card.Body>
        </Card>
    );
}

function SearchResultCard() {
    return (
        <Card>
            <ListGroup className="list-group-flush">
                <ListGroupItem>Cras justo odio</ListGroupItem>
                <ListGroupItem>Dapibus ac facilisis in</ListGroupItem>
                <ListGroupItem>Vestibulum at eros</ListGroupItem>
            </ListGroup>
        </Card>
    );
}

function Search() {
    return (
        <Row>
            <Col>
                <Row>
                    <Col>
                        <SearchCard/>
                    </Col>
                </Row>

                <Row>
                    <Col>
                        <SearchResultCard/>
                    </Col>
                </Row>
            </Col>
        </Row>
    );
}

export default Search;