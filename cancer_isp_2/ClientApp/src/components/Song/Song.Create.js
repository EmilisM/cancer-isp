import React from "react";
import { Card, Row, Col, Form, Button } from "react-bootstrap";

function SongCreationCard() {
    return (
        <Card>
            <Card.Header>
                Create a new song
            </Card.Header>
            <Card.Body>
                <Form>
                    <Form.Group>
                        <Form.Label>Song name</Form.Label>
                        <Form.Control type="text" placeholder="Song name"/>
                    </Form.Group>
                    <Form.Group>
                        <Form.Label>Artist full name</Form.Label>
                        <Form.Control type="text" placeholder="Artist full name"/>
                    </Form.Group>
                    <Form.Group>
                        <Button variant="primary" type="Repeat password">
                            Create
                        </Button>
                    </Form.Group>
                </Form>
            </Card.Body>
        </Card>
    );
}

function SongCreate() {
    return (
        <Row>
            <Col>

                <Row>
                    <Col>
                        <SongCreationCard/>
                    </Col>
                </Row>

            </Col>
        </Row>
    );
}

export default SongCreate;