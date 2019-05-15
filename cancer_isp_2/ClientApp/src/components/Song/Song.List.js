import React from "react";
import { Card, Row, Col, ListGroup, ListGroupItem } from "react-bootstrap";
import { Link } from "react-router-dom";
import PropTypes from "prop-types";

function NewSongCard({ songs }) {
    NewSongCard.propTypes = {
        songs: PropTypes.array
    };

    return (
        <Card>
            <Card.Header>
                New songs
            </Card.Header>
            <ListGroup className="list-group-flush">
                {songs.map(song => (
                    <ListGroupItem key={song.id}>
                        <Link to={`/song/${song.id}`}>{song.artists.map(artist => artist.artist.alias).join(", ")} - {song.name}</Link>
                    </ListGroupItem>
                ))}
            </ListGroup>
        </Card>
    );
}

function CreateNewSongCard() {
    return (
        <Card>
            <Card.Header>
                Want to create a new song ?
            </Card.Header>
            <Card.Body>
                <div className="form-group">
                    <label>Use this link</label>
                </div>
                <div className="form-group">
                    <Link to="/song/create">Create new song</Link>
                </div>
            </Card.Body>
        </Card>
    );
}

class SongList extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            songs: []
        };
    }

    componentDidMount() {
        fetch("api/song/new")
            .then(res => res.json())
            .then(
                (result) => {
                    this.setState({
                        songs: result
                    });
                });
    }

    render() {
        return (
            <Row>
                <Col>

                    <Row>
                        <Col>
                            <NewSongCard {...this.state}/>
                        </Col>
                    </Row>

                    <Row>
                        <Col>
                            <CreateNewSongCard />
                        </Col>
                    </Row>

                </Col>
            </Row>
        );
    }
}

export default SongList;