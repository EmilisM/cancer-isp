﻿import React from "react";
import { Card, Row, Col, ListGroup, ListGroupItem } from "react-bootstrap";
import { Link } from "react-router-dom";
import PropTypes from "prop-types";

function NewArtistCard({ artists }) {
    NewArtistCard.propTypes = {
        artists: PropTypes.array
    };

    return (
        <Card>
            <Card.Header>
                New artists
            </Card.Header>
            <ListGroup className="list-group-flush">
                {artists.map(artist => (
                    <ListGroupItem key={artist.id}>
                        <Link to={`/artist/${artist.id}`}>{artist.alias} {artist.fullName}</Link>
                    </ListGroupItem>
                ))}
            </ListGroup>
        </Card>
    );
}

function CreateNewArtistCard() {
    return (
        <Card>
            <Card.Header>
                Want to create a new artist ?
            </Card.Header>
            <Card.Body>
                <div className="form-group">
                    <label>Use this link</label>
                </div>
                <div className="form-group">
                    <Link to="/artist/create">Create new artist</Link>
                </div>
            </Card.Body>
        </Card>
    );
}

class ArtistList extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            artists: []
        };
    }

    componentDidMount() {
        fetch("api/artist/new")
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        artists: result
                    });
                });
    }

    render() {
        return (
            <div>
                <Row>
                    <Col>

                        <Row>
                            <Col>
                                <NewArtistCard {...this.state}/>
                            </Col>
                        </Row>

                        <Row>
                            <Col>
                                <CreateNewArtistCard />
                            </Col>
                        </Row>

                    </Col>

                </Row>
            </div>
        );
    }
}

export default ArtistList;