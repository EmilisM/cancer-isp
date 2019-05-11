import React from "react";
import { Card, Row, Col, ListGroup, ListGroupItem } from "react-bootstrap";

function NewSongList() {
    return (
        <Card>
            <Card.Header>
                New songs
            </Card.Header>
            <ListGroup className="list-group-flush">
                <ListGroupItem>Cras justo odio</ListGroupItem>
                <ListGroupItem>Dapibus ac facilisis in</ListGroupItem>
                <ListGroupItem>Vestibulum at eros</ListGroupItem>
            </ListGroup>
        </Card>
    );
}

function SongList() {
    return (
        <Row>
            <Col>

                <Row>
                    <Col>
                        <NewSongList/>
                    </Col>
                </Row>

                <Row>
                    <Col>
                    </Col>
                </Row>

            </Col>
        </Row>
    );
}

export default SongList;