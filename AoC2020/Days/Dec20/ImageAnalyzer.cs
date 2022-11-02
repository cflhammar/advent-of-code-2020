using AoC2020.Helpers;

namespace AoC2020.Days.Dec20;

public class ImageAnalyzer
{
    private List<Tile> _remainingTiles = new ();
    private List<List<Tile?>> _board = new();
    private List<List<bool>> _result = new();
    private static readonly int _maxSize = 50;
    private int _rowMin = _maxSize;
    private int _rowMax;
    private int _colMin = _maxSize;
    private int _colMax;
    private readonly int _seaMonsterSize = 15;

    public ImageAnalyzer(List<string> inputData)
    {
        foreach (var rawTile in inputData)
        {
            var tile = new Tile(rawTile);
            _remainingTiles.Add(tile);
        }

        InitiateBoard();
    }

      public void PlaceTiles()
    {
        var first = _remainingTiles[0];
        _board[_maxSize/2][_maxSize/2] = first;
        _remainingTiles.RemoveAt(0);

        while (_remainingTiles.Count > 0)
        {
            for (int i = 0; i < _remainingTiles.Count; i++)
            {
                if (PlaceNextTile(i))
                {
                    _remainingTiles.RemoveAt(i);
                    break;
                }
            }
        }
    }

    private bool PlaceNextTile(int k)
    {
        var tile = _remainingTiles[k];

        for (int i = 0; i < _board.Count; i++)
        {
            for (int j = 0; j < _board[0].Count; j++)
            {
                if (_board[i][j] != null)
                {
                    var adjustedTile = TryToPlaceTile(tile, i + 1, j);
                    if (adjustedTile != null)
                    {
                        _board[i + 1][j] = adjustedTile;
                        return true;
                    }

                    adjustedTile = TryToPlaceTile(tile, i - 1, j);
                    if (adjustedTile != null)
                    {
                        _board[i - 1][j] = adjustedTile;
                        return true;
                    }
                    
                    adjustedTile = TryToPlaceTile(tile, i, j + 1);
                    if (adjustedTile != null)
                    {
                        _board[i][j + 1] = adjustedTile;
                        return true;
                    }
                    
                    adjustedTile = TryToPlaceTile(tile, i, j - 1);
                    if (adjustedTile != null)
                    {
                        _board[i][j - 1] = adjustedTile;
                        return true;
                    }
                }
            }
        }

        return false;
    }

    private Tile? TryToPlaceTile(Tile tile, int row, int col)
    {
        if (_board[row][col] != null) return null;
        
        for (var flip = 0; flip < 2; flip++)
        {
            for (var rot = 0; rot < 4; rot++)
            {
                if (MatchAllSides(tile, row, col)) return tile;
                tile.Rotate90();
            }
            tile.Flip();
        }
        
        return null;
    }

    private bool MatchAllSides(Tile tile, int row, int col)
    {
        return MatchBottom(tile, _board[row + 1][col]) &&
               MatchTop(tile, _board[row - 1][col]) &&
               MatchRight(tile, _board[row][col + 1]) &&
               MatchLeft(tile, _board[row][col -1]);
    }
    
    private bool MatchBottom(Tile newTopTile, Tile? existingBottomTile)
    {
        if (existingBottomTile == null) return true;
        var topRow = existingBottomTile.Content[0];
        var bottomRow = newTopTile.Content[^1]; 

        for (int i = 0; i < topRow.Count; i++)
        {
            if (topRow[i] != bottomRow[i]) return false;
        }

        return true;
    }
    
    private bool MatchTop(Tile newBottomTile, Tile? existingTopTile)
    {
        if (existingTopTile == null) return true;
        var topRow = newBottomTile.Content[0];
        var bottomRow = existingTopTile.Content[^1];

        for (int i = 0; i < topRow.Count; i++)
        {
            if (topRow[i] != bottomRow[i]) return false;
        }

        return true;
    }
    
    private bool MatchRight(Tile newLeftTile, Tile? existingRightTile)
    {
        if (existingRightTile == null) return true;
        
        for (int i = 0; i < newLeftTile.Content.Count; i++)
        {
            var left = newLeftTile.Content[i][newLeftTile.Content[0].Count - 1];
            var right = existingRightTile.Content[i][0];
            
            if (left != right) return false;
        }
        
        return true;
    }
    
    private bool MatchLeft(Tile newRightTile, Tile? existingLeftTile)
    {
        if (existingLeftTile == null) return true;


        for (int i = 0; i < newRightTile.Content.Count; i++)
        {
            if (newRightTile.Content[i][0] != existingLeftTile.Content[i][existingLeftTile.Content[0].Count - 1]) return false;
        }
        
        return true;
    }
    
    public Int64 GetSumOfCorners()
    {
        for (int row = 0; row < _maxSize; row++)
        {
            for (int col = 0; col < _maxSize; col++)
            {
                if (_board[row][col] != null)
                {
                    if (row > _rowMax) _rowMax = row;
                    if (row < _rowMin) _rowMin = row;
                    if (col > _colMax) _colMax = col;
                    if (col < _colMin) _colMin = col;
                }
            }
        }

        return _board[_rowMin][_colMin]!.Id * _board[_rowMin][_colMax]!.Id * 
               _board[_rowMax][_colMin]!.Id * _board[_rowMax][_colMax]!.Id;
    }


    public void CombineTilesInBoardToResult()
    {
        var extractedBoard = RemoveBordersOfTiles(RemoveEmptyRowsAndCols());

        for (int tileRow = 0; tileRow < extractedBoard.Count; tileRow++)
        {
            var offset = tileRow * (extractedBoard[0][0]!.Content.Count );

            for (int tileCol = 0; tileCol < extractedBoard[0].Count; tileCol++)
            {
               var tile = extractedBoard[tileRow][tileCol];
                
                for (int row = 0; row < tile!.Content.Count; row++)
                {
                    if (tileCol == 0 ) _result.Add(new List<bool>());
                    _result[row + offset].AddRange(tile.Content[row]);
                }
                
            }
        }
    }

    private int FindSeaMonsters()
    {
        var numberOfSeaMonsters = 0;

        for (int row = 0; row < _result.Count - 2; row++)
        {
            for (int col = 0; col < _result[0].Count - 19; col++)
            {
                if (_result[row][col + 18] &&
                    _result[row + 1][col] &&
                    _result[row + 1][col + 5] &&
                    _result[row + 1][col + 6] &&
                    _result[row + 1][col + 11] &&
                    _result[row + 1][col + 12] &&
                    _result[row + 1][col + 17] &&
                    _result[row + 1][col + 18] &&
                    _result[row + 1][col + 19] &&
                    _result[row + 2][col + 1] &&
                    _result[row + 2][col + 4] &&
                    _result[row + 2][col + 7] &&
                    _result[row + 2][col + 10] &&
                    _result[row + 2][col + 13] &&
                    _result[row + 2][col + 16])
                {
                    numberOfSeaMonsters++;
                }
            }
        }

        return numberOfSeaMonsters;
    }

    public int GetHabitatRoughness()
    {
        var helper = new RotateAndFlipListList();

        var maxNumSeaMonsters = 0;
        for (int flip = 0; flip < 2; flip++)
        {
            for (int rot = 0; rot < 3; rot++)
            {
                _result = helper.Rotate90(_result);
                var found = FindSeaMonsters();

                if (found > maxNumSeaMonsters) maxNumSeaMonsters = found;
            }
            _result = helper.Flip(_result);
        }
        
        return TotalTruePixels() - _seaMonsterSize * maxNumSeaMonsters;
    }
    
    private List<List<Tile?>> RemoveEmptyRowsAndCols()
    {
        var temp = _board.Skip(_rowMin).Take(_rowMax-_rowMin + 1).ToList();
        return temp.Select(e => e.Skip(_colMin).Take(_colMax - _colMin + 1).ToList()).ToList();
    }

    private List<List<Tile?>> RemoveBordersOfTiles(List<List<Tile?>> tiles)
    {
        foreach (var row in tiles)
        {
            foreach (var tile in row)
            {
                tile?.RemoveBorder();
            }
        }

        return tiles;
    }


    private int TotalTruePixels()
    {
        return _result.Sum(row => row.Count(e => e));
    }

    private void InitiateBoard()
    {
        for (var i = 0; i < _maxSize; i++)
        {
            _board.Add( new List<Tile?>());
            for (var j = 0; j < _maxSize; j++)
            {
                _board[i].Add(null);
            }
        }
    }
}