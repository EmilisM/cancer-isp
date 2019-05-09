import React from "react";
import { Card, Row, Col, Form, Button, ListGroup, ListGroupItem } from "react-bootstrap";

function SearchCard() {
    return (
        <Card>
            <Card.Header>
                Search
            </Card.Header>
            <Card.Body>
                <Form.Group>
                    <Form.Label>Search</Form.Label>
                    <br/>
                    <Form.Control type="email" placeholder="Search"/>
                </Form.Group>
                <Form.Group>
                    <Button variant="primary" type="submit">
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