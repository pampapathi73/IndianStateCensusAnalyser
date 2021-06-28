using NUnit.Framework;
using IndianStateCensusAnalyser;
using IndianStateCensusAnalyser.DTO;
using System.Collections.Generic;
using static IndianStateCensusAnalyser.CensusAnalyser;

namespace CensusAnalyserTest
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCensusFilePath = @"C:\Users\Pampapathi K\Desktop\Pampapathi\IndianStateCensusAnalyser\CensusAnalyserTest\Utility\IndiaStateCensusData.csv";
        static string wrongIndianStateCensusFilePath = @"C:\Users\Prashik Jaware\source\repos\DesignPrinciples\Indian-State-Census-Analyzer\CensusAnalyserTest\CsvFiles\WrongIndiaStateCensusData.csv";
        static string IndianStateCensusFilePathWithWrongDelimeter = @"C:\Users\Pampapathi K\Desktop\Pampapathi\IndianStateCensusAnalyser\CensusAnalyserTest\Utility\DelimiterIndiaStateCensusData.csv";
        static string wrongIndianStateCensusFileType = @"C:\Users\Pampapathi K\Desktop\Pampapathi\IndianStateCensusAnalyser\CensusAnalyserTest\Utility\IndiaStateCensusData.txt";
        static string IndianStateCensusFilePathWithWrongHeader = @"C:\Users\Pampapathi K\Desktop\Pampapathi\IndianStateCensusAnalyser\CensusAnalyserTest\Utility\WrongIndiaStateCensusData.csv";
        static string indianStateCodeHeaders = @"SrNo,State Name,TIN,StateCode";
        static string indianStateCodePath = @"C:\Users\Pampapathi K\Desktop\Pampapathi\IndianStateCensusAnalyser\CensusAnalyserTest\Utility\IndiaStateCode.csv";
        static string WrongIndianStateCodeFilePath = @"C:\Users\Dell\DotNetProjects\Ce\WrongIndiaStateCode.csv";
        static string WrongIndianStateCodeFileTypePath = @"C:\Users\Pampapathi K\Desktop\Pampapathi\IndianStateCensusAnalyser\CensusAnalyserTest\Utility\IndiaStateCode.txt";
        static string IndianStateCodeFilePathWrongDelimeter = @"C:\Users\Pampapathi K\Desktop\Pampapathi\IndianStateCensusAnalyser\CensusAnalyserTest\Utility\DelimiterIndiaStateCode.csv";
        static string IndianStateCodeFilePathWrongHeader = @"C:\Users\Pampapathi K\Desktop\Pampapathi\IndianStateCensusAnalyser\CensusAnalyserTest\Utility\WrongIndiaStateCode.csv";
        CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecords;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecords = new Dictionary<string, CensusDTO>();
        }
        [Test]
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            Assert.AreEqual(29, totalRecord.Count);
        }
        [Test]
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);

        }
        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFileType, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }
        [Test]
        public void GivenIndianCensusDataFile_WhenWrongDelimeter_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(IndianStateCensusFilePathWithWrongDelimeter, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }
        [Test]
        public void GivenIndianCensusDataFile_WhenWrongHeader_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(IndianStateCensusFilePathWithWrongHeader, Country.INDIA, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }
        [Test]
        public void GivenIndianStateCodeFile_WhenRead_ShouldReturnCensusDataCount()
        {
            stateRecords = censusAnalyser.LoadCensusData(indianStateCodePath, Country.INDIA, indianStateCodeHeaders);
            Assert.AreEqual(37, stateRecords.Count);
        }
        [Test]
        public void GivenWrongStateCodeFile_WhenRead_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(WrongIndianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }

        [Test]
        public void GivenWrongIndianStateCodeFileType_WhenRead_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(WrongIndianStateCodeFileTypePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
        }
        [Test]
        public void GivenIndianStateCodeFile_WhenWrongDelimeter_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(IndianStateCodeFilePathWrongDelimeter, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);
        }
        [Test]
        public void GivenIndianStateCodeFile_WhenWrongHeader_ShouldReturnCustomException()
        {
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(IndianStateCodeFilePathWrongHeader, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }
    }
}