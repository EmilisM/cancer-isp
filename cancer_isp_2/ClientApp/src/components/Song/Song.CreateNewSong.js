import React from "react";
import { Card } from "react-bootstrap";
import { Link } from "react-router-dom";


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

export default CreateNewSongCard;